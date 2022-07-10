using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
	public event Action<bool> PlayerFalling;
	public event Action<bool> GroundedChanged;

	public Rigidbody2D _rigidbody;
	public Animator animator;

	public bool IsGounded 
	{
		get => grounded;
		private set 
		{
			grounded = value;
			GroundedChanged?.Invoke(grounded);
		}
	}

	private float jumpForce;
	private float movementSmoothing;
	private bool airControl = false;
	private float airResistance;

	private float fallingThreshold;

	[SerializeField]
	private LayerMask GroundLayer;
	[SerializeField]
	private Transform groundCheck;

    const float groundedRadius = .2f;
	private bool grounded = false;
	private bool facingRight = true;
	private Vector3 velocity = Vector3.zero;

	private bool isFalling = false;

    private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
    }

    private void Update()
    {
        GroundCheck();

        if (_rigidbody.velocity.y < fallingThreshold && !isFalling)
        {
            isFalling = true;
            PlayerFalling?.Invoke(isFalling);
        }
        else if (_rigidbody.velocity.y > fallingThreshold && isFalling)
        {
            isFalling = false;
            PlayerFalling?.Invoke(isFalling);
        }
    }

    private void GroundCheck()
	{
		IsGounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, GroundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
				IsGounded = true;
            }
        }
    }

    public void SetConfig(MoveConfig moveConfig)
	{
		fallingThreshold = moveConfig.FallingThreshold;
		jumpForce = moveConfig.JumpForce;
		movementSmoothing = moveConfig.MovementSmoothing;
		airControl = moveConfig.AirControl;
		_rigidbody.gravityScale = moveConfig.GravityScale;
		airResistance = moveConfig.AirResistance;
	}

	public void Move(float inputMove)
    {
        if (grounded || airControl)
        {
			animator.SetFloat("Speed", Math.Abs(inputMove));

			animator.SetBool("Ground", grounded);

			Vector3 targetVelocity = new Vector2(inputMove, _rigidbody.velocity.y);

			float smoothValue = movementSmoothing;

			if (!grounded && airControl)
				smoothValue += airResistance;

			_rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, smoothValue); ;


			if (inputMove > 0 && !facingRight)
                Flip();
            else if (inputMove < 0 && facingRight)
                Flip();
		}
	}

    public void PerformJump(bool ignoreGround = false)
    {
		PerformJump(jumpForce, ignoreGround);
	}

	public void PerformJump(float _jumpForce, bool ignoreGround = false)
	{
		if (grounded || ignoreGround)
		{
			grounded = false;
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);

			_rigidbody.AddForce(new Vector2(0f, _jumpForce));

			animator.SetTrigger("Jump");
		}
	}

	private void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

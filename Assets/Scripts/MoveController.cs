using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
	[HideInInspector]
	public float jumpForce = 400f;
	[HideInInspector]
	public float movementSmoothing = .05f;
	[HideInInspector]
	public bool airControl = false;

	[SerializeField]
	private LayerMask GroundLayer;
	[SerializeField]
	private Transform groundCheck;

    const float groundedRadius = .2f;
	private bool grounded;
	private Rigidbody2D _rigidbody;
	private bool facingRight = true;
	private Vector3 velocity = Vector3.zero;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void SetConfig(MoveConfig moveConfig)
	{
		jumpForce = moveConfig.JumpForce;
		movementSmoothing = moveConfig.MovementSmoothing;
		airControl = moveConfig.AirControl;
		_rigidbody.gravityScale = moveConfig.GravityScale;
	}

	private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, GroundLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
			}
		}
	}

	public void Move(float move, bool jump)
	{
		if (grounded || airControl)
		{

			Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
			_rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, movementSmoothing);

			if (move > 0 && !facingRight)
			{
				Flip();
			}
			else if (move < 0 && facingRight)
			{
				Flip();
			}
		}
		if (grounded && jump)
		{
			grounded = false;
			_rigidbody.AddForce(new Vector2(0f, jumpForce));
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

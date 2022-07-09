using UnityEngine;

public class DoubleJumpSpell : ActiveSpell
{
    [Header("If true jumpforce will ignored")]
    public bool UsePlayerJumpForce;

    public float jumpForce;

    public override void CastSpell()
    {
        if(!UsePlayerJumpForce)
            SpellCaster.GetComponent<MoveController>().PerformJump(jumpForce, true);
        else
            SpellCaster.GetComponent<MoveController>().PerformJump(true);
    }
}


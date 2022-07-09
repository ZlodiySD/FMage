using UnityEngine;

public class DoubleJumpSpell : MagicSpell
{
    [Header("If true jumpforce will ignored")]
    public bool UsePlayerJumpForce;

    public float jumpForce;

    public override void CastSpell()
    {
        if(!UsePlayerJumpForce)
            spellCaster.GetComponent<MoveController>().PerformJump(jumpForce, true);
        else
            spellCaster.GetComponent<MoveController>().PerformJump(true);
    }
}


using UnityEngine;

public class GravityChangeActive : ActiveSpell
{
    [Header("How much will gravity change")]
    [Range(0.1f, 100)]
    public float GravityChangeValue;

    private PlayerGravityChanger playerGravityChanger = new PlayerGravityChanger();

    public override void CastSpell()
    {
        var isGrounded = SpellCaster.GetComponent<MoveController>().IsGounded;

        if (isGrounded)
            return;

        playerGravityChanger.SetGravity(SpellCaster, GravityChangeValue);

        SpellCaster.GetComponent<MoveController>().GroundedChanged += GravityChangeActive_GroundedChanged;
    }

    private void GravityChangeActive_GroundedChanged(bool grounded)
    {
        if (grounded)
        {
            playerGravityChanger.ResetGravity(SpellCaster);
            SpellCaster.GetComponent<MoveController>().GroundedChanged -= GravityChangeActive_GroundedChanged;
        }
    }
}
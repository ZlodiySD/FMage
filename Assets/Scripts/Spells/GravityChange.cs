using UnityEngine;

public class GravityChange : PassiveSpell
{
    [Header("How much will gravity change")]
    [Range(0.1f, 10)]
    public float GravityChangeScale;

    public override void ApplySpell()
    {
        var player = SpellCaster.GetComponent<PlayerController>();
        player.moveController.PlayerFalling += MoveController_PlayerFalling;
    }

    public override void DisapplySpell()
    {
        var player = SpellCaster.GetComponent<PlayerController>();
        player.moveController.PlayerFalling -= MoveController_PlayerFalling;
        ResetGravity();
    }

    private void ResetGravity()
    {
        SpellCaster.GetComponent<PlayerController>().ResetGravityScale();
    }

    private void ChangeGravity()
    {
        var player = SpellCaster.GetComponent<PlayerController>();
        var newGravity = player.GetConfigs().moveConfig.GravityScale / GravityChangeScale;

        player.SetGravityScale(newGravity);
    }

    private void MoveController_PlayerFalling(bool isFalling)
    {
        if (isFalling)
            ChangeGravity();
        else
            ResetGravity();
    }
}
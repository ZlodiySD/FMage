using UnityEngine;

public class GravityChangePassive : PassiveSpell
{
    [Header("How much will gravity change")]
    [Range(0.1f, 10)]
    public float GravityChangeScale;

    private PlayerGravityChanger playerGravityChanger = new PlayerGravityChanger();

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
        playerGravityChanger.ResetGravity(SpellCaster);
    }

    private void ChangeGravity()
    {
        playerGravityChanger.DivideGravity(SpellCaster, GravityChangeScale);
    }

    private void MoveController_PlayerFalling(bool isFalling)
    {
        if (isFalling)
            ChangeGravity();
        else
            ResetGravity();
    }
}

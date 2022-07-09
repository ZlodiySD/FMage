using UnityEngine;

public class GravityChange : PassiveSpell
{
    [Header("How much will gravity change")]
    [Range(0.1f, 5)]
    public float GravityChangeScale;

    public override void ApplySpell()
    {
        var player = SpellCaster.GetComponent<PlayerController>();

        var newGravity = player.GetConfigs().moveConfig.GravityScale / GravityChangeScale;

        player.SetGravityScale(newGravity);
    }

    public override void DisapplySpell()
    {
        SpellCaster.GetComponent<PlayerController>().ResetGravityScale();
    }
}
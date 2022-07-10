public class PassiveBuffer : PassiveSpell
{
    public BuffType buffType;

    public override void ApplySpell()
    {
        SpellCaster.GetComponent<PlayerController>().playerBuffs.SetBuffState(buffType, true);
    }

    public override void DisapplySpell()
    {
        SpellCaster.GetComponent<PlayerController>().playerBuffs.SetBuffState(buffType, false);
    }
}

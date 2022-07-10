using System;

public class PlayerBuffs
{
    public bool FireResistance;

    public void SetBuffState(BuffType buffType, bool isActive)
    {
        switch (buffType)
        {
            case BuffType.FireResistance:
                FireResistance = isActive;
                break;
        }
    }

    public bool IsBuffActive(BuffType requiredBuffType)
    {
        switch (requiredBuffType)
        {
            case BuffType.FireResistance:
                return FireResistance;
            default:
                return false;
        }
    }
}

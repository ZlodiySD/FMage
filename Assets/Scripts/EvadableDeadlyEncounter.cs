using UnityEngine;

public class EvadableDeadlyEncounter : DeadlyEncounter
{
    [Header("Buff that saves from taking damage")]
    public BuffType requiredBuffType;

    public override void TriggerDeath(PlayerController playerController)
    {
        bool isBuffActive = playerController.playerBuffs.IsBuffActive(requiredBuffType);

        if(!isBuffActive)
            base.TriggerDeath(playerController);
    }
}

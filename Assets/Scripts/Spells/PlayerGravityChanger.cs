using UnityEngine;

public class PlayerGravityChanger
{
    public void DivideGravity(GameObject target, float GravityChangeScale)
    {
        var player = target.GetComponent<PlayerController>();
        var newGravity = player.GetConfigs().moveConfig.GravityScale / GravityChangeScale;

        player.SetGravityScale(newGravity);
    }

    public void SetGravity(GameObject target, float GravityChange)
    {
        var player = target.GetComponent<PlayerController>();
        var newGravity = GravityChange;

        player.SetGravityScale(newGravity);
    }

    public void ResetGravity(GameObject target)
    {
        target.GetComponent<PlayerController>().ResetGravityScale();
    }
}

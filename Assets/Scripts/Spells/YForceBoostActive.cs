using UnityEngine;

public class YForceBoostActive : ActiveSpell
{
    [Header("Force applied to the player along the y-axis")]
    public float BoostForce;

    public override void CastSpell()
    {
        SpellCaster.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,BoostForce));
    }
}
using UnityEngine;

public interface ISpell
{
    public string SpellName { get; set; }

    public GameObject SpellCaster { get; set; }

    public void SetCaster(GameObject caster);
}
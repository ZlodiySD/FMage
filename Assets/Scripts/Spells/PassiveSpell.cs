using UnityEngine;
using System;

[Serializable]
public abstract class PassiveSpell : MonoBehaviour, ISpell
{
    public string SpellName { get; set; }

    public GameObject SpellCaster { get; set; }

    public void SetCaster(GameObject caster) => SpellCaster = caster;

    public abstract void ApplySpell();

    public abstract void DisapplySpell();
}

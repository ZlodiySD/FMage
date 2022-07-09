using UnityEngine;
using System;

[Serializable]
public abstract class ActiveSpell: MonoBehaviour, ISpell
{
    public string SpellName { get; set; }

    public GameObject SpellCaster{ get; set; }

    public void SetCaster(GameObject caster) => SpellCaster = caster;

    public abstract void CastSpell();
}
using UnityEngine;
using System;

[Serializable]
public abstract class MagicSpell: MonoBehaviour
{
    public string spellName;

    protected GameObject spellCaster;

    public void SetCaster(GameObject caster) => spellCaster = caster;

    public abstract void CastSpell();
}


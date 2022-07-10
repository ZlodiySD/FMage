using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster
{
    public event Action<MagicSphereConfig> SphereChanged;

    private SphereHolder sphereHolder;

    private MagicSphereConfig activeSphere;

    public SpellCaster(SphereHolder spellsHolder)
    {
        this.sphereHolder = spellsHolder;

        this.sphereHolder.SpheresChanged += SphereHolder_SpheresChanged; ;
    }

    private void SphereHolder_SpheresChanged(List<MagicSphereConfig> spheres)
    {
        if(spheres.Count == 0)
        {
            if(activeSphere.PassiveSpell)
                activeSphere.PassiveSpell.DisapplySpell();
            activeSphere = null;
            return;
        }

        var newSphere = spheres[spheres.Count - 1];
        SetAciveSphere(newSphere);
    }

    private void SetAciveSphere(MagicSphereConfig magicSphere)
    {
        if(activeSphere != null)
            activeSphere.PassiveSpell.DisapplySpell();

        activeSphere = magicSphere;

        if (activeSphere.PassiveSpell)
            activeSphere.PassiveSpell.ApplySpell();

        SphereChanged?.Invoke(activeSphere);
    }

    //public void CastSpell(SpellType spellType, Action<MagicSphereConfig, SpellType> SpellCasted)
    //{
    //    if (!activeSphere)
    //        return;

    //    switch (spellType)
    //    {
    //        case SpellType.Primary:
    //            if (!activeSphere.ActiveSpell)
    //                return;
    //            activeSphere.ActiveSpell.CastSpell();
    //            Debug.Log("Spell casted: " + activeSphere.ActiveSpell.SpellName);
    //            break;

    //        case SpellType.Secondary:
    //            if (!activeSphere.PassiveSpell)
    //                return;
    //            activeSphere.ActiveSpell.CastSpell();
    //            Debug.Log("Spell casted: " + activeSphere.PassiveSpell.SpellName);
    //            break;
    //    }

    //    SpellCasted?.Invoke(activeSphere, spellType);
    //}

    public void CastSpell(Action<MagicSphereConfig, SpellType> SpellCasted)
    {
        if (!activeSphere || !activeSphere.ActiveSpell)
            return;

        activeSphere.ActiveSpell.CastSpell();
        Debug.Log("Spell casted: " + activeSphere.ActiveSpell.SpellName);

        SpellCasted?.Invoke(activeSphere, SpellType.Secondary);
    }
}

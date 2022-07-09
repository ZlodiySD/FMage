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
            activeSphere = null;
            return;
        }

        var newSphere = spheres[spheres.Count - 1];
        SetAciveSphere(newSphere);
    }

    private void SetAciveSphere(MagicSphereConfig magicSphere)
    {
        activeSphere = magicSphere;

        SphereChanged?.Invoke(activeSphere);
    }

    public void CastSpell(SpellType spellType, Action<MagicSphereConfig, SpellType> SpellCasted)
    {
        if (!activeSphere)
            return;

        switch (spellType)
        {
            case SpellType.Primary:
                if (!activeSphere.primaryMagicSpell)
                    return;
                activeSphere.primaryMagicSpell.CastSpell();
                Debug.Log("Spell casted: " + activeSphere.primaryMagicSpell.spellName);
                break;

            case SpellType.Secondary:
                if (!activeSphere.secondaryMagicSpell)
                    return;
                activeSphere.secondaryMagicSpell.CastSpell();
                Debug.Log("Spell casted: " + activeSphere.secondaryMagicSpell.spellName);
                break;
        }

        SpellCasted?.Invoke(activeSphere, spellType);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class SphereHolder : MonoBehaviour
{
    public event Action<MagicSphereConfig> SphereCountMaxed;
    public event Action<List<MagicSphereConfig>> SpheresChanged;

    [HideInInspector]
    public int MaxSpellsCount;

    public List<MagicSphereConfig> magicSpheresConfigs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameLayers.Interacteble)
        {
            if (collision.gameObject.TryGetComponent(out MagicShpere magicShpere))
            {
                TryAddSphere(magicShpere);
            }
        }
    }

    public void SetConfig(SpellsHolderConfig spellsHolderConfig)
    {
        magicSpheresConfigs = new List<MagicSphereConfig>();
        MaxSpellsCount = spellsHolderConfig.MaxSpellsCount;
    }

    public void TryAddSphere(MagicShpere sphere)
    {
        if(magicSpheresConfigs.Count >= MaxSpellsCount)
        {
            SphereCountMaxed?.Invoke(sphere.magicShpereConfig);
            return;
        }

        AddSphere(sphere);
    }

    public void AddSphere(MagicShpere sphere)
    {
        sphere.SetCaster(gameObject);
        magicSpheresConfigs.Add(sphere.magicShpereConfig);

        SpheresChanged?.Invoke(magicSpheresConfigs);

        Debug.Log("Sphere added: " + sphere.magicShpereConfig.magicShpereName);
        sphere.DestroySphere();
    }

    public void RemoveSphere(MagicSphereConfig magicShpereConfig)
    {
        magicSpheresConfigs.Remove(magicShpereConfig);

        SpheresChanged?.Invoke(magicSpheresConfigs);

        Debug.Log("Sphere removed: " + magicShpereConfig.magicShpereName);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHolderIndicator : MonoBehaviour
{
    [SerializeField]
    private Transform firstPosition;
    [SerializeField]
    private Transform secondPosition;

    private GameObject firstSphere;
    private GameObject secondSphere;

    private SpellCaster spellCaster;
    private SphereHolder sphereHolder;

    private void FixedUpdate()
    {
        if (spellCaster != null)
            transform.position = sphereHolder.gameObject.transform.position + new Vector3(0,1,0);
    }

    public void Init(SphereHolder sphereHolder, SpellCaster spellCaster)
    {
        this.sphereHolder = sphereHolder;
        sphereHolder.SpheresChanged += SphereHolder_SpheresChanged;
        this.spellCaster = spellCaster;
    }

    private void SphereHolder_SpheresChanged(List<MagicSphereConfig> spheres)
    {
        if (spellCaster.activeSphere)
            firstSphere = Instantiate(spellCaster.activeSphere.sphereAnimation, transform);
        else
            if (firstSphere)
            Destroy(firstSphere);

        if (spellCaster.secondSphere)
            secondSphere = Instantiate(spellCaster.secondSphere.sphereAnimation, transform);
        else
            if (secondSphere)
            Destroy(secondSphere);
    }
}

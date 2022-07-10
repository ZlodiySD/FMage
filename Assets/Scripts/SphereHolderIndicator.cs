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

    private SphereHolder sphereHolder;

    public float followHight;

    private void FixedUpdate()
    {
        if (sphereHolder != null)
            transform.position = sphereHolder.gameObject.transform.position + new Vector3(0, followHight, 0);
    }

    public void Init(SphereHolder sphereHolder)
    {
        this.sphereHolder = sphereHolder;
        sphereHolder.SpheresChanged += SphereHolder_SpheresChanged;
    }

    private void SphereHolder_SpheresChanged(List<MagicSphereConfig> spheres)
    {
        DestroySphere(firstSphere);
        DestroySphere(secondSphere);

        if (spheres.Count == 0)
            return;

        var active = spheres[spheres.Count - 1];

        if (active)
        {
            DestroySphere(firstSphere);

            firstSphere = Instantiate(active.sphereAnimation,
                firstPosition.position, firstPosition.rotation, transform);
        }


        if (spheres.Count > 1)
        {
            var second = spheres[spheres.Count - 2];
            DestroySphere(secondSphere);

            secondSphere = Instantiate(second.sphereAnimation,
                secondPosition.position, secondPosition.rotation, transform);
        }
    }

    private void DestroySphere(GameObject sphere)
    {
        if (sphere)
            Destroy(sphere);
    }
}

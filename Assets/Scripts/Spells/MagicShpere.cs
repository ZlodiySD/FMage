using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShpere : MonoBehaviour
{
    public MagicSphereConfig magicShpereConfig;

    [SerializeField]
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider.radius = magicShpereConfig.pickUpRadius;
    }

    public void SetCaster(GameObject caster)
    {
        if(magicShpereConfig.ActiveSpell)
            magicShpereConfig.ActiveSpell.SetCaster(caster);

        if (magicShpereConfig.PassiveSpell)
            magicShpereConfig.PassiveSpell.SetCaster(caster);
    }

    public void DestroySphere()
    {
       Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, magicShpereConfig.pickUpRadius);
    }
#endif
}
using System;
using UnityEngine;

[Serializable]
public class MoveConfig
{
    public float MovementSpeed;
    public float JumpForce;

    [Range(0, 1f)]
    [Header("AKA inercia")]
    public float MovementSmoothing;

    [Header("Air settings")]
    public bool AirControl;

    [Range(0, 1f)]
    public float AirResistance;

    [Range(0, 10f)]
    [Header("Gravity force, default is 1")]
    public float GravityScale;

}

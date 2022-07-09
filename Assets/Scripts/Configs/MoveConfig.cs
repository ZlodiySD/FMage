using System;
using UnityEngine;

[Serializable]
public class MoveConfig
{
    [Tooltip("Falling speed value after which the player enters the falling state")]
    [Range(-10f, 0)]
    public float FallingThreshold;

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

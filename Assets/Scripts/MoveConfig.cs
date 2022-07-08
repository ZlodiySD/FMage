using System;
using UnityEngine;

[Serializable]
public class MoveConfig
{
    public float MovementSpeed;
    public float JumpForce;

    [Range(0, .5f)]
    public float MovementSmoothing;

    public bool AirControl;

    [Range(0, 10f)]
    public float PlayerGravity;
}

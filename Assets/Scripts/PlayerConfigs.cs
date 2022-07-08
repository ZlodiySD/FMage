using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigs", menuName = "Configs/PlayerConfig", order = 1)]
public class PlayerConfigs : ScriptableObject
{
    public MoveConfig moveConfig;
}

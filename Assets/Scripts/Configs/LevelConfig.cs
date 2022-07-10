using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigs", menuName = "Configs/LevelConfig", order = 3)]
public class LevelConfig : ScriptableObject
{
    public int LevelID;
    public double levelPassTimeInSeconds;
}
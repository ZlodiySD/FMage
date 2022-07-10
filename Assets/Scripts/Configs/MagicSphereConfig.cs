using UnityEngine;

[CreateAssetMenu(fileName = "MagicShpereConfigs", menuName = "Configs/MagicShpereConfigs", order = 2)]
public class MagicSphereConfig : ScriptableObject
{
    [Header("Will show radius in editor if Object selected")]

    public string magicShpereName;
    public float pickUpRadius;

    public ActiveSpell ActiveSpell;
    public PassiveSpell PassiveSpell;

    public GameObject sphereAnimation;
}
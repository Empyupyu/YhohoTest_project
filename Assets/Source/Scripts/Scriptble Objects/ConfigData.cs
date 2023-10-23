using UnityEngine;

[CreateAssetMenu(menuName = "Data/ConfigData")]
public sealed class ConfigData : ScriptableObject
{
    [field: SerializeField] public GameObject PlayerPrefab { get; private set; }
    [field: SerializeField] public float PlayerBaseSpeed { get; private set; }
}

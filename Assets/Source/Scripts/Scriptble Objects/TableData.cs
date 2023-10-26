using UnityEngine;

[CreateAssetMenu(menuName = "Data/TablesData")]
public sealed class TableData : ScriptableObject
{
    [field: SerializeField] public int Capacity { get; private set; }
    [field: SerializeField] public float EatingTime { get; private set; }
}

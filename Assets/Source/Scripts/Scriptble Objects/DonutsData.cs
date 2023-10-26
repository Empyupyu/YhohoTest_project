using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/DonutsData")]
public sealed class DonutsData : ScriptableObject
{
    [field: SerializeField] public List<GameObject> DonutsVariationPrefabs { get; private set; }
    [field: SerializeField] public float CookingRate { get; private set; }
    [field: SerializeField] public int CookOvenCapacity { get; private set; }
    [field: SerializeField] public float OffsetInStack { get; private set; }
}

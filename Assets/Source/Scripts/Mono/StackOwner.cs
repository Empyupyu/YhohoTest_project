using Leopotam.Ecs;
using TMPro;
using UnityEngine;
public class StackOwner : MonoBehaviour
{
    [field: SerializeField] public Transform StackPoint { get; private set; }
    [field: SerializeField] public Transform TextHolder { get; private set; }
    [field: SerializeField] public TextMeshProUGUI MaxText { get; private set; }
    public EcsEntity EcsEntity { get; private set; }

    public void Initialize(EcsEntity entity)
    {
        EcsEntity = entity;
    }
}

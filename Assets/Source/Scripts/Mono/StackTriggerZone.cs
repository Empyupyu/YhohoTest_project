using Leopotam.Ecs;
using UnityEngine;

public class StackTriggerZone : MonoBehaviour
{
    public EcsWorld EcsWorld { get; private set; }
    public EcsEntity EcsEntity { get; private set; }

    public void Initialize(EcsEntity ecsEntity, EcsWorld world)
    {
        EcsWorld = world;
        EcsEntity = ecsEntity;
    }

    private void OnTriggerEnter(Collider other)
    {
        var OnTriggerEnterEntity = EcsWorld.NewEntity();

        ref var request = ref OnTriggerEnterEntity.Get<AddClientRequestComponent>();
        request.MainEntity = EcsEntity;
        request.ClientEntity = other.GetComponent<StackOwner>().EcsEntity;
    }

    private void OnTriggerExit(Collider other)
    {
        var OnTriggerEnterEntity = EcsWorld.NewEntity();

        ref var request = ref OnTriggerEnterEntity.Get<RemoveClientRequestComponent>();
        request.MainEntity = EcsEntity;
        request.ClientEntity = other.GetComponent<StackOwner>().EcsEntity;
    }
}

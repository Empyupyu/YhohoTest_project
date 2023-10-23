using Leopotam.Ecs;
using UnityEngine;

public class PlayerRotationSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerTag, DirectionComponent, TransformReferenceComponent> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var direction = ref _filter.Get2(i);
            ref var transform = ref _filter.Get3(i);

            if (direction.Direction == Vector3.zero) continue;

            transform.Value.rotation = Quaternion.LookRotation(direction.Direction);
        }
    }
}

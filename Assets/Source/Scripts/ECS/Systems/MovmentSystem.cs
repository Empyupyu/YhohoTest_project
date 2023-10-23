using Leopotam.Ecs;
using UnityEngine;

public class MovmentSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;

    private readonly EcsFilter<TransformReferenceComponent, MovableComponent, DirectionComponent> _filter = null;

    public void Run()
    {
        Move();
    }

    private void Move()
    {
        foreach (var item in _filter)
        {
            ref var transformReferenceComponent = ref _filter.Get1(item);
            ref var movableComponent = ref _filter.Get2(item);
            ref var directionComponent = ref _filter.Get3(item);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref transformReferenceComponent.Value;

            var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);

            movableComponent.Agent.Move(rawDirection * movableComponent.Speed * Time.deltaTime);
        }
    }
}

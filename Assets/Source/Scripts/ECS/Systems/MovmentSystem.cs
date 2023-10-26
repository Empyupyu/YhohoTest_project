using Leopotam.Ecs;
using UnityEngine;
public class MovmentSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MovableComponent, DirectionComponent> _filter = null;

    public void Run()
    {
        Move();
    }

    private void Move()
    {
        foreach (var item in _filter)
        {
            ref var movableComponent = ref _filter.Get1(item);
            ref var direction = ref _filter.Get2(item);

            movableComponent.Agent.Move(direction.Direction * movableComponent.Speed * Time.deltaTime);
        }
    }
}

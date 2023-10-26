using Leopotam.Ecs;
public class EatingSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<StackComponent, TimerComponent, EatingComponent, TimerCompletedComponent> _eatFilter;

    public void Run()
    {
        foreach (var i in _eatFilter)
        {
            ref var entity = ref _eatFilter.GetEntity(i);
            ref var stack = ref _eatFilter.Get1(i);
            ref var timer = ref _eatFilter.Get2(i);

            var newEntity = _world.NewEntity();
            ref var request = ref newEntity.Get<RemoveFromStackRequestComponent>();

            var item = stack.Items[stack.Items.Count - 1];

            request.StackEntity = entity;
            request.Item = item;

            newEntity = _world.NewEntity();
            newEntity.Get<DestructRequestComponent>().GameObject = item.gameObject;

            if (stack.Items.Count == 1)
            {
                entity.Del<TimerComponent>();
            }

            entity.Del<TimerCompletedComponent>();
        }
    }
}

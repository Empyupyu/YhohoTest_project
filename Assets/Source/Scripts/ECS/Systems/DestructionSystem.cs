using Lean.Pool;
using Leopotam.Ecs;

public class DestructionSystem : IEcsRunSystem
{
    private readonly EcsFilter<DestructRequestComponent> _eatFilter;

    public void Run()
    {
        foreach (var item in _eatFilter)
        {
            ref var destroyItem = ref _eatFilter.Get1(item);

            LeanPool.Despawn(destroyItem.GameObject);
        }
    }
}

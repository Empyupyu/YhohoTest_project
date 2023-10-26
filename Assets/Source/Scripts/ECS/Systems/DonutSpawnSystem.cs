using Lean.Pool;
using Leopotam.Ecs;
using UnityEngine;
public class DonutSpawnSystem : IEcsRunSystem
{
    private readonly ConfigData _config;
    private readonly EcsFilter<CompleteCookComponent, StackComponent> _cookOvenFilter;

    public void Run()
    {
        foreach (var item in _cookOvenFilter)
        {
            ref var cookOvenEntity = ref _cookOvenFilter.GetEntity(item);
            ref var stack = ref _cookOvenFilter.Get2(item);

            var donut = LeanPool.Spawn(GetDonutRandomVariant(), stack.StackPoint);

            ref var addRequest = ref cookOvenEntity.Get<AddToStackRequestComponent>();
            addRequest.Item = donut.transform;
            addRequest.StackEntity = cookOvenEntity;

            ref var entity = ref _cookOvenFilter.GetEntity(item);
            entity.Del<CompleteCookComponent>();
        }
    }

    private GameObject GetDonutRandomVariant()
    {
        var donats = _config.DonutsData.DonutsVariationPrefabs;
        return donats[Random.Range(0, donats.Count)];
    }
}

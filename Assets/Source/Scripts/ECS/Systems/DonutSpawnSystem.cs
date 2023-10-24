using Leopotam.Ecs;
using UnityEngine;
public class DonutSpawnSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;
    private readonly EcsFilter<CompleteCookComponent, StackComponent> _cookOvenFilter;

    public void Run()
    {
        foreach (var item in _cookOvenFilter)
        {
            ref var cookOvenEntity = ref _cookOvenFilter.GetEntity(item);
            ref var stack = ref _cookOvenFilter.Get2(item);

            var donutEntity = _world.NewEntity();
            var donut = Object.Instantiate(GetDonutRandomVariant(), stack.Stack.transform);
            ref var pickUpble = ref donutEntity.Get<PickUpbleComponent>();

            ref var addToStack = ref cookOvenEntity.Get<AddToStackComponent>();
            addToStack.Item = donut.transform;

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

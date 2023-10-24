using Leopotam.Ecs;
using UnityEngine;

public class CookingSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    private readonly EcsFilter<TimerComponent, StackComponent>.Exclude<StackIsFullComponent> _cookOvenFilter;

    public void Run()
    {
        foreach (var item in _cookOvenFilter)
        {
            ref var entity = ref _cookOvenFilter.GetEntity(item);
            ref var timer = ref _cookOvenFilter.Get1(item);
            ref var stack = ref _cookOvenFilter.Get2(item);

            timer.Timer -= Time.deltaTime;

            if (timer.Timer > 0) continue;

            timer.Timer = _config.DonutsData.CookingRate;
            ref var completeCook = ref entity.Get<CompleteCookComponent>();
        }
    }
}

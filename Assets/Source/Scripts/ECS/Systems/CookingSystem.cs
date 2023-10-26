using Leopotam.Ecs;
public class CookingSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    private readonly EcsFilter<TimerComponent, StackComponent, TimerCompletedComponent, CookingComponent>.Exclude<StackIsFullComponent> _cookOvenFilter;

    public void Run()
    {
        foreach (var item in _cookOvenFilter)
        {
            ref var entity = ref _cookOvenFilter.GetEntity(item);
            ref var timer = ref _cookOvenFilter.Get1(item);
            ref var stack = ref _cookOvenFilter.Get2(item);

            ref var completeCook = ref entity.Get<CompleteCookComponent>();
            entity.Del<TimerCompletedComponent>();
        }
    }
}

using Leopotam.Ecs;

public class InitializeCookOvenSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    public void Init()
    {
        _game.CookOvenTransform = _scene.CookOven.transform;

        var stack = _game.CookOvenTransform.GetComponentInChildren<Stack>();
        stack.Initialize(_world);
        ref var timer = ref stack.Entity.Get<TimerComponent>();
        timer.Timer = _config.DonutsData.CookingRate;
        ref var initializeStack = ref stack.Entity.Get<InitializeStackComponent>();
        initializeStack.Stack = stack;
        initializeStack.Capacity = _config.DonutsData.CookOvenCapacity;
    }
}

using System.Collections.Generic;
using Leopotam.Ecs;

public class InitializeCookOvenSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    public void Init()
    {
        var entity = _world.NewEntity();
        _game.CookOvenTransform = _scene.CookOven.transform;

        ref var timer = ref entity.Get<TimerComponent>();
        ref var stackText = ref entity.Get<WorldUITextComponent>();
        ref var lookAtCameraUI = ref entity.Get<LookAtCameraUIComponent>();
        ref var initializeStack = ref entity.Get<InitializeStackComponent>();
        ref var cooking = ref entity.Get<CookingComponent>();
        entity.Get<ItemGiverComponent>();
        entity.Get<ClientsComponent>().Clients = new List<EcsEntity>();

        timer.StartTime = _config.DonutsData.CookingRate;
        timer.TimePassed = timer.StartTime;
        initializeStack.Capacity = _config.DonutsData.CookOvenCapacity;
        initializeStack.StackOwnerTransform = _game.CookOvenTransform;

        _game.CookOvenTransform.GetComponent<StackTriggerZone>().Initialize(entity, _world);
    }
}

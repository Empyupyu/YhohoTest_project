using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
public class InitializeStackSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    private readonly EcsFilter<InitializeStackComponent> _filter;

    public void Run()
    {
        foreach (var item in _filter)
        {
            ref var initializer = ref _filter.Get1(item);
            ref var entity = ref _filter.GetEntity(item);

            StackInitialize(entity, initializer.StackOwnerTransform, initializer.Capacity);
        }
    }

    private void StackInitialize(EcsEntity unit, Transform owner, int capacity)
    {
        var stackOwner = owner.GetComponent<StackOwner>();
        stackOwner.Initialize(unit);

        ref StackComponent stackComponent = ref unit.Get<StackComponent>();
        ref WorldUITextComponent stackText = ref unit.Get<WorldUITextComponent>();
        ref LookAtCameraUIComponent lookAtCameraUI = ref unit.Get<LookAtCameraUIComponent>();

        stackComponent.Capacity = capacity;
        stackComponent.StackPoint = stackOwner.StackPoint;
        stackComponent.Items = new List<Transform>();
        stackText.Holder = stackOwner.TextHolder;
        stackText.Text = stackOwner.MaxText;
        lookAtCameraUI.Holder = stackOwner.TextHolder;
    }
}

using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class InitializeStackSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    public void Init()
    {
        PlayerStackInitialize();
    }

    private void PlayerStackInitialize()
    {
        EcsEntity newEntity = _world.NewEntity();
        ref var stack = ref newEntity.Get<StackComponent>();

        var stackView = _game.PlayerTransform.GetComponentInChildren<Stack>();
        stack.StackPoint = stackView.transform;
        stack.Capacity = _config.PlayerBaseStackCapacity;
        stack.Items = new List<Transform>();
    }
}

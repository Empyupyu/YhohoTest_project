﻿using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInitializeSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;

    public void Init()
    {
        var playerGO = SpawnPlayerModel();
        _game.PlayerTransform = playerGO.transform;

        EcsEntity playerEntity = _world.NewEntity();

        ref var player = ref playerEntity.Get<PlayerTag>();
        ref var joystick = ref playerEntity.Get<JoystickComponent>();
        ref var movable = ref playerEntity.Get<MovableComponent>();
        ref var transform = ref playerEntity.Get<TransformReferenceComponent>();
        ref var direction = ref playerEntity.Get<DirectionComponent>();
        ref var animator = ref playerEntity.Get<AnimatorComponent>();
        ref var initializeStack = ref playerEntity.Get<InitializeStackComponent>();

        animator.Animator = playerGO.transform.GetComponentInChildren<Animator>();
        movable.Agent = playerGO.GetComponent<NavMeshAgent>();
        movable.Speed = _config.PlayerBaseSpeed;
        transform.Value = playerGO.transform;
        joystick.Joystick = _scene.Joystick;
        initializeStack.Capacity = _config.PlayerBaseStackCapacity;
        initializeStack.StackOwnerTransform = _game.PlayerTransform;
    }

    private GameObject SpawnPlayerModel()
    {
        return Object.Instantiate(_config.PlayerPrefab, _scene.PlayerSpawnPoint.position, Quaternion.identity);
    }
}

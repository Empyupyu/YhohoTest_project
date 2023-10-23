﻿using Leopotam.Ecs;

public class InitializePlayerCameraSystem : IEcsInitSystem
{
    private readonly EcsWorld _ecsWorld;
    private readonly SceneData _scene;
    private readonly GameData _game;

    public void Init()
    {
        EcsEntity playerEntity = _ecsWorld.NewEntity();
        ref var cameraAngle = ref playerEntity.Get<CameraEuerAngleComponent>();

        _scene.PlayerCamera.m_Follow = _game.PlayerTransform;
        _scene.PlayerCamera.m_LookAt = _game.PlayerTransform;
        cameraAngle.Value.y = _scene.PlayerCamera.transform.eulerAngles.y;
    }
}

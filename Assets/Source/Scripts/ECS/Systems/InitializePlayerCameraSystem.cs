using Leopotam.Ecs;

public class InitializePlayerCameraSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private ConfigData _config;
    private SceneData _scene;
    private GameData _game;

    public void Init()
    {
        EcsEntity playerEntity = _ecsWorld.NewEntity();
        ref var cameraAngle = ref playerEntity.Get<CameraEuerAngleComponent>();

        _scene.PlayerCamera.m_Follow = _game.PlayerTransform;
        _scene.PlayerCamera.m_LookAt = _game.PlayerTransform;
        cameraAngle.Value = _scene.PlayerCamera.transform.eulerAngles;
    }
}

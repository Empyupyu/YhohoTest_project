using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSpawnSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private ConfigData _config;
    private SceneData _scene;

    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<PlayerTag>();
        ref var joystick = ref playerEntity.Get<JoystickComponent>();
        ref var movable = ref playerEntity.Get<MovableComponent>();
        ref var transform = ref playerEntity.Get<TransformReferenceComponent>();
        ref var direction = ref playerEntity.Get<DirectionComponent>();

        var playerGO = SpawnPlayerModel();

        movable.Agent = playerGO.GetComponent<NavMeshAgent>();
        movable.Speed = _config.PlayerBaseSpeed;
        transform.Value = playerGO.transform;
        joystick.Joystick = _scene.Joystick;
    }

    private GameObject SpawnPlayerModel()
    {
        return Object.Instantiate(_config.PlayerPrefab, _scene.PlayerSpawnPoint.position, Quaternion.identity);
    }
}

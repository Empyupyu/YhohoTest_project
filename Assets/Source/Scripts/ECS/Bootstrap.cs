using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class Bootstrap : MonoBehaviour
{
    [SerializeField] private ConfigData _config;
    [SerializeField] private SceneData _scene;

    private GameData _game = new GameData();
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddInjections();
        AddSystems();
        AddOneFrame();

        _systems.Init();
    }

    private void AddInjections()
    {
        _systems.Inject(_config);
        _systems.Inject(_scene);
        _systems.Inject(_game);
    }

    private void AddSystems()
    {
        _systems.
            Add(new PlayerSpawnSystem()).
            Add(new PlayerInputSystem()).
            Add(new MovmentSystem());
    }

    private void AddOneFrame()
    {

    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        if (_systems == null) return; 

        _systems.Destroy();
        _systems = null;
        _world.Destroy();
        _world = null;
    }
}

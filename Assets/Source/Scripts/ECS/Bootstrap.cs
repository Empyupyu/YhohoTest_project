using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class Bootstrap : MonoBehaviour
{
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

    }

    private void AddSystems()
    {
        _systems.
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

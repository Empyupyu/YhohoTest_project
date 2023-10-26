using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public sealed class Bootstrap : MonoBehaviour
{
    [SerializeField] private ConfigData _config;
    [SerializeField] private SceneData _scene;

    private GameData _game = new GameData();
    private EcsWorld _world;
    private EcsSystems _systemsUpdate;
    private EcsSystems _systemsLateUpdate;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _world = new EcsWorld();
        _systemsUpdate = new EcsSystems(_world);
        _systemsLateUpdate = new EcsSystems(_world);
        _systemsUpdate.ConvertScene();
        _systemsLateUpdate.ConvertScene();

        AddInjections();
        AddSystems();
        AddOneFrame();

        _systemsUpdate.Init();
        _systemsLateUpdate.Init();
    }

    private void AddInjections()
    {
        _systemsUpdate.Inject(_config);
        _systemsUpdate.Inject(_scene);
        _systemsUpdate.Inject(_game);
        _systemsLateUpdate.Inject(_config);
        _systemsLateUpdate.Inject(_scene);
        _systemsLateUpdate.Inject(_game);
    }

    private void AddSystems()
    {
        _systemsUpdate.
        Add(new PlayerInitializeSystem()).
        Add(new InitializePlayerCameraSystem()).
        Add(new InitializeCookOvenSystem()).
        Add(new InitializeTablesSystem()).
        Add(new StackUISystem()).
        Add(new InitializeStackSystem())
            .OneFrame<InitializeStackComponent>().
        Add(new PlayerInputSystem()).
        Add(new PlayerRotationSystem()).
        Add(new MovmentSystem()).
        Add(new TimerSystem()).
        Add(new ClientsSystem())
            .OneFrame<AddClientRequestComponent>()
            .OneFrame<RemoveClientRequestComponent>().
        Add(new ItemGiverSystem()).
        Add(new ItemReceiverSystem()).
        Add(new EatingLaunchSystem()).
        Add(new EatingSystem()).
        Add(new CookingSystem()).
        Add(new DonutSpawnSystem()).
            OneFrame<NewItemInStackEventComponent>().
        Add(new StackSystem()).
            OneFrame<AddToStackRequestComponent>().
            OneFrame<RemoveFromStackRequestComponent>().
        Add(new DestructionSystem()).
            OneFrame<DestructRequestComponent>().
        Add(new PlayerAnimationSystem())
        ;

        _systemsLateUpdate.Add(new LookAtCameraWorldUISystem());
    }

    private void AddOneFrame()
    {

    }

    private void Update()
    {
        _systemsUpdate.Run();

    }

    private void LateUpdate()
    {
        _systemsLateUpdate.Run();
    }

    private void OnDestroy()
    {
        if (_systemsUpdate == null) return; 

        _systemsUpdate.Destroy();
        _systemsUpdate = null;
        _world.Destroy();
        _world = null;
    }
}

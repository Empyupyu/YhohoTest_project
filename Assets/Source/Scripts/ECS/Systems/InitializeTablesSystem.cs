using System.Collections.Generic;
using Leopotam.Ecs;

public class InitializeTablesSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;
    private readonly SceneData _scene;
    private readonly ConfigData _config;

    public void Init()
    {
        foreach (var table in _scene.Tables)
        {
            EcsEntity tableEntity = _world.NewEntity();
            ref var stackInitialize = ref tableEntity.Get<InitializeStackComponent>();
            tableEntity.Get<EatingComponent>();
            tableEntity.Get<ItemReceiverComponent>();
            tableEntity.Get<ClientsComponent>().Clients = new List<EcsEntity>();

            stackInitialize.StackOwnerTransform = table;
            stackInitialize.Capacity = _config.TableData.Capacity;

            table.GetComponent<StackTriggerZone>().Initialize(tableEntity, _world);
        }
    }
}

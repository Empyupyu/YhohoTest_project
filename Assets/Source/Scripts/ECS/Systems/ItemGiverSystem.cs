using Leopotam.Ecs;

public class ItemGiverSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<HasClientsComponent, StackComponent, ItemGiverComponent> _hasClientFilter;

    public void Run()
    {
        foreach (var i in _hasClientFilter)
        {
            ref var giverStack = ref _hasClientFilter.Get2(i);

            if (giverStack.Items.Count == 0) continue;

            ref var itemGiverEntity = ref _hasClientFilter.GetEntity(i);
            ref var clients = ref itemGiverEntity.Get<ClientsComponent>();

            GiveItemToClient(giverStack, clients, itemGiverEntity);
        } 
    }

    private void GiveItemToClient(StackComponent giverStack, ClientsComponent clients, EcsEntity itemGiverEntity)
    {
        int itemIndex = giverStack.Items.Count - 1;

        foreach (var clientEntity in clients.Clients)
        {
            if (itemIndex < 0) break;

            ref var clientStack = ref clientEntity.Get<StackComponent>();
            bool isMax = clientStack.Items.Count == clientStack.Capacity;
            if (isMax) break;

            var addEntity = _world.NewEntity();
            ref var addToStack = ref addEntity.Get<AddToStackRequestComponent>();

            var removeEntity = _world.NewEntity();
            ref var removeFromStack = ref removeEntity.Get<RemoveFromStackRequestComponent>();

            var item = giverStack.Items[itemIndex];

            addToStack.Item = item;
            addToStack.StackEntity = clientEntity;

            removeFromStack.Item = item;
            removeFromStack.StackEntity = itemGiverEntity;

            itemIndex--;
        }
    }
}

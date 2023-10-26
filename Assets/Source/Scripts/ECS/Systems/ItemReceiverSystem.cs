using Leopotam.Ecs;

public class ItemReceiverSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<HasClientsComponent, StackComponent, ItemReceiverComponent>.Exclude<StackIsFullComponent> _hasClientFilter;

    public void Run()
    {
        foreach (var i in _hasClientFilter)
        {
            ref var stackReceiver = ref _hasClientFilter.Get2(i);

            ref var itemReceiverEntity = ref _hasClientFilter.GetEntity(i);
            ref var clients = ref itemReceiverEntity.Get<ClientsComponent>();

            PutItem(stackReceiver, clients, itemReceiverEntity);
        }
    }

    private void PutItem(StackComponent stack, ClientsComponent clients, EcsEntity itemReceiverEntity)
    {
        foreach (var clientEntity in clients.Clients)
        {
            ref var clientStack = ref clientEntity.Get<StackComponent>();
            int itemIndex = clientStack.Items.Count - 1;

            bool isMax = stack.Items.Count == stack.Capacity;
            if (itemIndex < 0 || isMax) break;

            var entity = _world.NewEntity();
            ref var addToStack = ref entity.Get<AddToStackRequestComponent>();
            ref var removeFromStack = ref entity.Get<RemoveFromStackRequestComponent>();

            var item = clientStack.Items[itemIndex];

            addToStack.Item = item;
            addToStack.StackEntity = itemReceiverEntity;

            removeFromStack.Item = item;
            removeFromStack.StackEntity = clientEntity;
        }
    }
}

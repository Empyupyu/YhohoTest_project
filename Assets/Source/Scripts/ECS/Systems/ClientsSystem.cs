using Leopotam.Ecs;

public class ClientsSystem : IEcsRunSystem
{
    private readonly EcsFilter<AddClientRequestComponent> _addClientFilter;
    private readonly EcsFilter<RemoveClientRequestComponent> _removeClientFilter;

    public void Run()
    {
        AddClient();
        RemoveClient();

    }
    private void AddClient()
    {
        foreach (var item in _addClientFilter)
        {
            ref var request = ref _addClientFilter.Get1(item);
            ref var clients = ref request.MainEntity.Get<ClientsComponent>();

            clients.Clients.Add(request.ClientEntity);

            if (clients.Clients.Count == 1) request.MainEntity.Get<HasClientsComponent>();
        }
    }

    private void RemoveClient()
    {
        foreach (var item in _removeClientFilter)
        {
            ref var request = ref _removeClientFilter.Get1(item);
            ref var clients = ref request.MainEntity.Get<ClientsComponent>();

            clients.Clients.Remove(request.ClientEntity);

            if (clients.Clients.Count == 0) request.MainEntity.Del<HasClientsComponent>();
        }
    }
}


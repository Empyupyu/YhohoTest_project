using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
[Serializable]
public struct ItemReceiverComponent
{

}
[Serializable]
public struct ItemGiverComponent
{

}
[Serializable]
public struct HasClientsComponent
{
   
}
[Serializable]
public struct ClientsComponent
{
    public List<EcsEntity> Clients;
}
[Serializable]
public struct RemoveClientRequestComponent
{
    public EcsEntity ClientEntity;
    public EcsEntity MainEntity;
}
[Serializable]
public struct AddClientRequestComponent
{
    public EcsEntity ClientEntity;
    public EcsEntity MainEntity;
}

[Serializable]
public struct AddToStackRequestComponent
{
    public Transform Item;
    public EcsEntity StackEntity;
}

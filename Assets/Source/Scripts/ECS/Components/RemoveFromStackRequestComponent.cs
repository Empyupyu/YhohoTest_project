using System;
using Leopotam.Ecs;
using UnityEngine;

[Serializable]
public struct RemoveFromStackRequestComponent
{
    public Transform Item;
    public EcsEntity StackEntity;
}

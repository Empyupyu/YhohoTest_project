using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct StackComponent
{
    public Transform StackPoint;
    public List<Transform> Items;
    public int Capacity;
}

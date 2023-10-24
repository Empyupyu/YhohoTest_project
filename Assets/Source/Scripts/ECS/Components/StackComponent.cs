using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct StackComponent
{
    public Stack Stack;
    public List<Transform> Items;
    public int Capacity;
}

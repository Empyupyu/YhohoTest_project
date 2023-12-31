using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public sealed class SceneData : MonoBehaviour
{
    [field: SerializeField] public Joystick Joystick { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera PlayerCamera { get; private set; }
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
    [field: SerializeField] public Transform CookOven { get; private set; }
    [field: SerializeField] public List<Transform> Tables { get; private set; }

}

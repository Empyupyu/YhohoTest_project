using Cinemachine;
using UnityEngine;

public sealed class SceneData : MonoBehaviour
{
    [field: SerializeField] public Joystick Joystick { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera PlayerCamera { get; private set; }
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }

}

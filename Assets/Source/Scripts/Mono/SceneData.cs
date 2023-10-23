using UnityEngine;

public sealed class SceneData : MonoBehaviour
{
    [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
}

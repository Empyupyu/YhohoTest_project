using Leopotam.Ecs;

public class LookAtCameraWorldUISystem : IEcsRunSystem
{
    private readonly GameData _game;
    private readonly SceneData _scene;
    private readonly EcsFilter<LookAtCameraUIComponent> _filter = null;

    public void Run()
    {
        foreach (var item in _filter)
        {
            ref var lookAtCamera = ref _filter.Get1(item);
            lookAtCamera.Holder.LookAt(_scene.PlayerCamera.transform);
        }
    }
}

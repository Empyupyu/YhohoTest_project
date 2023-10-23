using Leopotam.Ecs;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerTag, DirectionComponent, JoystickComponent> _filter = null;
    private readonly EcsFilter<CameraEuerAngleComponent> _cameraFilter = null;

    public void Run()
    {
        UpdateDirectionComponents();
    }

    private void UpdateDirectionComponents()
    {
        foreach (var item in _filter)
        {
            ref var directionComponent = ref _filter.Get2(item);
            ref var joystickComponent = ref _filter.Get3(item);
            ref var cameraEuerAngleComponent = ref _cameraFilter.Get1(0);

            directionComponent.Direction.x = joystickComponent.Joystick.Direction.x;
            directionComponent.Direction.z = -joystickComponent.Joystick.Direction.y;

            var cameraAngleOffset = Quaternion.Euler(cameraEuerAngleComponent.Value) * directionComponent.Direction;
            directionComponent.Direction = cameraAngleOffset;
        }
    }
}

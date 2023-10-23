using Leopotam.Ecs;
using UnityEngine;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<PlayerTag, DirectionComponent, AnimatorComponent> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var input = ref _filter.Get2(i);
            ref var animator  = ref _filter.Get3(i);

            var value = input.Direction == Vector3.zero ? 0f : 1f;
            animator.Animator.SetFloat("Move", value);
        }
    }
}

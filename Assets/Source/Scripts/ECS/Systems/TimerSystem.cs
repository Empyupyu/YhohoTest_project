using Leopotam.Ecs;
using UnityEngine;

public class TimerSystem : IEcsRunSystem
{
    private readonly EcsFilter<TimerComponent> _timerFilter;

    public void Run()
    {
        foreach (var item in _timerFilter)
        {
           ref var timer = ref _timerFilter.Get1(item);
           ref var entity = ref _timerFilter.GetEntity(item);
           timer.TimePassed -= Time.deltaTime;

           if (timer.TimePassed > 0) continue;

           timer.TimePassed = timer.StartTime;
           entity.Get<TimerCompletedComponent>();      
        }
    }
}

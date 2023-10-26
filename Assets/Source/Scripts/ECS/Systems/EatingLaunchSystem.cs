using Leopotam.Ecs;

public class EatingLaunchSystem : IEcsRunSystem
{
    private readonly ConfigData _config;
    private readonly EcsFilter<NewItemInStackEventComponent, StackComponent, EatingComponent> _newItemInStackComponent;
    public void Run()
    {
        foreach (var item in _newItemInStackComponent)
        {
            ref var entity = ref _newItemInStackComponent.GetEntity(item);
            ref var timer  = ref entity.Get<TimerComponent>();
            ref var stack  = ref entity.Get<StackComponent>();

            timer.StartTime = _config.TableData.EatingTime;
            timer.TimePassed = timer.StartTime;
        }
    }
}

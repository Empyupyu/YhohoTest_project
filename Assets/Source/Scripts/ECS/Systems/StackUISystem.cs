using Leopotam.Ecs;

public class StackUISystem : IEcsRunSystem
{
    private readonly EcsFilter<UpdateUIComponent, WorldUITextComponent, StackComponent> _stackUIFilter;

    public void Run()
    {
        foreach (var item in _stackUIFilter)
        {
            ref var entity = ref _stackUIFilter.GetEntity(item);
            ref var uiText = ref _stackUIFilter.Get2(item);
            ref var stack = ref _stackUIFilter.Get3(item);

            bool isFull = stack.Capacity <= stack.Items.Count;

            uiText.Holder.gameObject.SetActive(isFull);

            entity.Del<UpdateUIComponent>();
        } 
    }
}

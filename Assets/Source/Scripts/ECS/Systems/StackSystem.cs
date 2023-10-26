using Leopotam.Ecs;
using UnityEngine;
public class StackSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly ConfigData _config;
    private readonly SceneData _scene;
    private readonly GameData _game;
                                                                                                                    
    private readonly EcsFilter<AddToStackRequestComponent> _addToStackFilter;
    private readonly EcsFilter<RemoveFromStackRequestComponent> _removeFromStackFilter;
    //private readonly EcsFilter<ItemTransferComponent>  _itemTransferOutFilter;

    public void Run()
    {
        AddItemToStack();
        //MoveItemsToRightStack();
        RemoveItemFromStack();
    }

    //private void MoveItemsToRightStack()
    //{
    //    foreach (var container in _itemTransferOutFilter)
    //    {
    //        ref var entity = ref _itemTransferOutFilter.GetEntity(container);
    //        ref var transfer = ref _itemTransferOutFilter.Get1(container);

    //        bool hasIntemIn = transfer.Main.Has<ItemInComponent>();

    //        if (hasIntemIn)
    //        {
    //            MoveItemsByFilter(transfer.Other, transfer.Main);
    //        }
    //        else
    //        {
    //            MoveItemsByFilter(transfer.Main, transfer.Other);
    //        }
          
    //        entity.Del<ItemTransferComponent>();
    //    }
    //}

    //private void MoveItemsByFilter(EcsEntity first, EcsEntity second)
    //{
    //    ref var outStack = ref first.Get<StackComponent>();
    //    ref var inStack = ref second.Get<StackComponent>();
    //    ref var stackInCapacityText = ref second.Get<WorldUITextComponent>();

    //    if (!HasSlot(outStack)) first.Get<UpdateUIComponent>();

    //    MoveItemsFromStackToStack(outStack, inStack);

    //    first.Del<StackIsFullComponent>();
    //    second.Get<NewItemInStackComponent>();

    //    if(!HasSlot(inStack))
    //    {
    //        second.Get<UpdateUIComponent>();
    //        second.Get<StackIsFullComponent>();
    //    }
    //}

    //private void MoveItemsFromStackToStack(StackComponent outStack, StackComponent inStack)
    //{
    //    for (int i = 0; i < outStack.Items.Count; i++)
    //    {
    //        var item = outStack.Items[i];

    //        if (HasSlot(inStack))
    //        {
    //            outStack.Items.Remove(item);
    //            inStack.Items.Add(item);
    //            SetNewParent(item, inStack);
    //            SortStack(outStack);

    //            i--;
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }
    //}

    private void AddItemToStack()
    {
        foreach (var item in _addToStackFilter)
        {
            ref var request = ref _addToStackFilter.Get1(item);
            ref var stack = ref request.StackEntity.Get<StackComponent>();

            var itemToStack = request.Item;
            itemToStack.parent = stack.StackPoint;

            itemToStack.localPosition = new Vector3(0, stack.Items.Count * _config.DonutsData.OffsetInStack, 0);

            stack.Items.Add(request.Item);
            request.StackEntity.Get<NewItemInStackEventComponent>();
            
            if (HasSlot(stack)) continue;

            request.StackEntity.Get<StackIsFullComponent>();
            request.StackEntity.Get<UpdateUIComponent>();
        }
    }

    private void RemoveItemFromStack()
    {
        foreach (var item in _removeFromStackFilter)
        {
            ref var request = ref _removeFromStackFilter.Get1(item);
            ref var stack = ref request.StackEntity.Get<StackComponent>();

            if (!HasSlot(stack))
            {
                request.StackEntity.Del<StackIsFullComponent>();
            }

            stack.Items.Remove(request.Item);        
            request.StackEntity.Get<UpdateUIComponent>();
        }
    }

    private bool HasSlot(StackComponent stack)
    {
        return stack.Items.Count < stack.Capacity;
    }
}

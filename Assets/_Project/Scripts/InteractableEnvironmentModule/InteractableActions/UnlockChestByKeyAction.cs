using System.Collections.Generic;
using _Project.Scripts.ConditionModule;
using _Project.Scripts.ConditionModule.Task;
using _Project.Scripts.InventoryModule;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.InteractableEnvironmentModule.InteractableActions
{
    
    public class UnlockChestByKeyAction : BaseInteractableAction
    {
        [SerializeField] private InventoryItem _requiredItem;
        [SerializeField] private List<InventoryItem> _dropedItems;
        [SerializeField] private TaskTypeEnum _taskType;

        [Inject] 
        private InventoryModel _inventoryModel;
        [Inject] 
        private CurrentTaskProvider _currentTaskProvider;

        private CheckItemInInventoryCondition _itemInInventoryCondition;
        private bool _isUnlocked = false;

        private void Start()
        {
            _itemInInventoryCondition = new CheckItemInInventoryCondition(_inventoryModel, _requiredItem);
        }

        public override void Action()
        {
            if (_itemInInventoryCondition.Status.Value == false || _isUnlocked)
                return;

            if (_dropedItems.Count != 0)
            {
                foreach (var item in _dropedItems)
                {
                    GameObject obj = item.Prefab;
                    
                    if (obj.TryGetComponent(out TakeInventoryItemAction action))
                    {
                        action.Init(item);
                        //action.Action();
                        _inventoryModel.RemoveItem(_requiredItem);
                        _inventoryModel.AddItem(item);
                    }
                    else
                    {
                        Debug.Log($"Couldn't get the component from prefab {obj.name}");
                    }
                }
            }
            
            if (_taskType != TaskTypeEnum.None)
                _currentTaskProvider.SetCompleteTask(_taskType);

            _isUnlocked = true;
        }
    }
}
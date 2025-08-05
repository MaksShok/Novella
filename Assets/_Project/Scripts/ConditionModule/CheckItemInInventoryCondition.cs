using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.ConditionModule.Task;
using _Project.Scripts.InventoryModule;
using _Project.Scripts.Misc;

namespace _Project.Scripts.ConditionModule
{
    public class CheckItemInInventoryCondition : ICondition
    {
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryItem _requiredItem;
        private readonly ReactiveProperty<bool> _itemInInventory = new ();

        public IReadOnlyReactiveProperty<bool> Status => _itemInInventory;
        
        public CheckItemInInventoryCondition(InventoryModel inventoryModel, InventoryItem requiredItem)
        {
            _inventoryModel = inventoryModel;
            _requiredItem = requiredItem;
            
            _inventoryModel.OnChangeInventory += RefreshCondition;
        }

        private void RefreshCondition()
        {
            List<InventoryItem> inventoryItemsCopy = new List<InventoryItem>(_inventoryModel.Items);
            _itemInInventory.Value = inventoryItemsCopy.Any(item => item.Id == _requiredItem.Id);
        }
    }
}
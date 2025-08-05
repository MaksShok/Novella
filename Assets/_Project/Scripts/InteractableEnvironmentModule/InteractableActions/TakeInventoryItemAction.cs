using _Project.Scripts.InventoryModule;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.InteractableEnvironmentModule.InteractableActions
{
    public class TakeInventoryItemAction : BaseInteractableAction
    {
        [Inject] 
        private InventoryModel _inventoryModel;

        private InventoryItem _item;

        public void Init(InventoryItem inventoryItem)
        {
            _item = inventoryItem;
        }
        
        public override void Action()
        {
            if (_item != null)
                _inventoryModel.AddItem(_item);
            else
            {
                Debug.Log("Inventory Item is null");
            }
        }
    }
}
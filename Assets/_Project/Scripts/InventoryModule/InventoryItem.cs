using UnityEngine;

namespace _Project.Scripts.InventoryModule
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/InventoryItem")]
    public class InventoryItem : ScriptableObject
    {
        public string Id;
        public Sprite IconSprite;
        public GameObject Object;
    }
}
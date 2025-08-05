using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.InventoryModule
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] 
        private Image _iconImage;

        public void UpdateIcon(Sprite newIconSprite)
        {
            _iconImage.sprite = newIconSprite;
        }

        public void DeleteIcon()
        {
            _iconImage.sprite = default;
        }
    }
}
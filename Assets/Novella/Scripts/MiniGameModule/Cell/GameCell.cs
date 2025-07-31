using UnityEngine;
using UnityEngine.UI;

namespace Novella.Scripts.MiniGameModule.Cell
{
    public class GameCell: MonoBehaviour
    {
        [SerializeField] private Sprite _zeroSprite;
        [SerializeField] private Sprite _crossSprite;

        [SerializeField] private Sprite _cellSprite;
        [SerializeField] private Button _button;

        private GameCellModel _cellModel;

        private void Awake()
        {
            _button.onClick.AddListener(HandleDisplayPlayerValue);
        }

        public void InitialCellModel(GameCellModel cellModel)
        {
            _cellModel = cellModel;
            _cellModel.CellValueChanged += DisplayValue;
        }

        public void HandleDisplayPlayerValue()
        {
            
        }

        private void DisplayValue(CellValue cellValue)
        {
            if (cellValue == CellValue.Cross)
            {
                ChangeCellState(_crossSprite);
                
            }
            else if (cellValue == CellValue.Zero)
            {
                ChangeCellState(_zeroSprite);
            }
        }

        private void ChangeCellState(Sprite sprite)
        {
            _cellSprite = sprite;
            _button.onClick.RemoveAllListeners();
            _cellModel.CellValueChanged -= DisplayValue;
        }
    }
}
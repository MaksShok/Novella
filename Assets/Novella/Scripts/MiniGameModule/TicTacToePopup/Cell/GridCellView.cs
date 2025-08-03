using UnityEngine;
using UnityEngine.UI;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup.Cell
{
    public class GridCellView: MonoBehaviour
    {
        [SerializeField] private Sprite _zeroSprite;
        [SerializeField] private Sprite _crossSprite;

        [SerializeField] private Image _cellImage;
        [SerializeField] private Button _button;

        private GridCellModel _cellModel;

        private void Awake()
        {
            _button.onClick.AddListener(HandleDisplayValue);
        }

        public void InitialCellModel(GridCellModel cellModel)
        {
            _cellModel = cellModel;
            _cellModel.CellValueChanged += DisplayChangedValue;
        }

        public void HandleDisplayValue()
        {
            if (GameRules.PlayerStepping)
            {
                _cellModel.SetCellValue(GameRules.PlayerCellValue);
            }
            else
            {
                Debug.LogErrorFormat("Не ваш ход!!!");
            }
        }

        private void DisplayChangedValue(CellValue cellValue)
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
            _cellImage.sprite = sprite;
            _button.onClick.RemoveAllListeners();
            _cellModel.CellValueChanged -= DisplayChangedValue;
        }

        private void OnDestroy()
        {
            _cellModel.CellValueChanged -= DisplayChangedValue;
        }
    }
}
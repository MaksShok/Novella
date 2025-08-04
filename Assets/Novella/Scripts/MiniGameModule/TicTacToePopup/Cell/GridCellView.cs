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

        private GridCellModel _model;

        private void Awake()
        {
            ApplyCellImageTransparency(0);
            _button.onClick.AddListener(OnClick);
        }

        public void InitialCellModel(GridCellModel cellModel)
        {
            _model = cellModel;
            _model.CellValueChanged += DisplayChangedValue;
        }

        public void OnClick()
        {
            _model.ProcessPlayerClick();
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
            else
            {
                _cellImage.sprite = default;
                ApplyCellImageTransparency(0);
            }
        }

        private void ChangeCellState(Sprite sprite)
        {
            _cellImage.sprite = sprite;
            ApplyCellImageTransparency(1);
        }

        private void ApplyCellImageTransparency(float a)
        {
            Color color = _cellImage.color;
            color.a = a;
            _cellImage.color = color;
        }

        private void OnDestroy()
        {
            _model.CellValueChanged -= DisplayChangedValue;
        }
    }
}
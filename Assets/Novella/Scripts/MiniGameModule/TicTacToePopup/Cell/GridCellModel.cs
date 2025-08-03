using System;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup.Cell
{
    public class GridCellModel
    {
        public event Action<CellValue> CellValueChanged;
        public int StrIndex { get; }
        public int RowIndex { get; }

        public CellValue CellValue
        {
            get => _value;
            set
            {
                _value = value;
                CellValueChanged?.Invoke(_value);
            }
        }

        private CellValue _value = CellValue.None;
        
        private MoveStrategy _moveStrategy;
        
        public GridCellModel(int strIndex, int rowIndex)
        {
            StrIndex = strIndex;
            RowIndex = rowIndex;
        }

        public void SetMoveStrategy(MoveStrategy moveStrategy)
        {
            _moveStrategy = moveStrategy;
        }

        public void ProcessPlayerClick()
        {
            _moveStrategy.MakePlayerMove(StrIndex, RowIndex);
        }
    }
    
    public enum CellValue
    {
        None = 0,
        Cross = 1,
        Zero = 2,
    }
}
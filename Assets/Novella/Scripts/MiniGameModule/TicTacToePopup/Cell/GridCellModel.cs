using System;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup.Cell
{
    public class GridCellModel
    {
        private readonly MoveStrategy _moveStrategy;
        
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
        
        public GridCellModel(int strIndex, int rowIndex, MoveStrategy moveStrategy)
        {
            StrIndex = strIndex;
            RowIndex = rowIndex;
            
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
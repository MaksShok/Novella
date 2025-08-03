using System;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup.Cell
{
    public class GridCellModel
    {
        public int StrIndex { get; }
        public int RowIndex { get; }
        
        public event Action<CellValue> CellValueChanged;

        public CellValue Value => _value;
        private CellValue _value = CellValue.None;
        
        public GridCellModel(int strIndex, int rowIndex)
        {
            StrIndex = strIndex;
            RowIndex = rowIndex;
        }

        public void SetCellValue(CellValue value)
        {
            if (_value == CellValue.None && value != CellValue.None)
            { 
                _value = value;
                CellValueChanged?.Invoke(_value);
            }
        }
    }
    
    public enum CellValue
    {
        None = 0,
        Cross = 1,
        Zero = 2,
    }
}
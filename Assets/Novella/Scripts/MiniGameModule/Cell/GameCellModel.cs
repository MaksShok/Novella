using System;

namespace Novella.Scripts.MiniGameModule.Cell
{
    public class GameCellModel
    {
        public readonly int X;
        public readonly int Y;
        
        public event Action<CellValue> CellValueChanged;

        public CellValue Value => _value;
        private CellValue _value = CellValue.None;
        
        public GameCellModel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetCellType(CellValue value)
        {
            _value = value;
            CellValueChanged?.Invoke(value);
        }
    }
    
    public enum CellValue
    {
        None = 0,
        Cross = 1,
        Zero = 2,
    }
}
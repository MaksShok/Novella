using System.Collections.Generic;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup
{
    public class GridData
    {
        public const int SideGridLength = 3;
        
        public static int CellsInGrid => SideGridLength * SideGridLength;
        
        public IReadOnlyList<GridCellModel> CellModels => _cellModels;
        private GridCellModel[] _cellModels = new GridCellModel[9];

        public GridData()
        {
            for (int str = 0; str < SideGridLength; str++)
            {
                for (int row = 0; row < SideGridLength; row++)
                {
                    int index = str + row + (SideGridLength - 1) * str;
                    _cellModels[index] = new GridCellModel(str, row);
                }
            }
        }

        public bool TryChangeCellValue(int strIndex, int rowIndex, CellValue newCellValue)
        {
            int index = strIndex + rowIndex + (SideGridLength - 1) * strIndex;
            CellValue cellValue = _cellModels[index].Value;
            
            if (cellValue == CellValue.None && newCellValue != CellValue.None)
            {
                _cellModels[index].SetCellValue(newCellValue);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
using System.Linq;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public class GameValidator : IGameValidator
    {
        public bool CheckWin(GridData gridData, int strIndex, int rowIndex, CellValue value)
        {
            return CheckLine(gridData, strIndex, rowIndex, value) ||
                   CheckColumn(gridData, strIndex, rowIndex, value) ||
                   CheckDiagonal(gridData, strIndex, rowIndex, value);
        }
        
        public bool CheckDraw(GridData gridData)
        {
            return gridData.CellModels.All(cell => cell.CellValue != CellValue.None);
        }
        
        private bool CheckLine(GridData gridData, int strIndex, int rowIndex, CellValue value)
        {
            for (int col = 0; col < GridData.SideGridLength; col++)
            {
                if (gridData.CellModels[strIndex * GridData.SideGridLength + col].CellValue != value)
                    return false;
            }
            return true;
        }
        
        private bool CheckColumn(GridData gridData, int strIndex, int rowIndex, CellValue value)
        {
            for (int row = 0; row < GridData.SideGridLength; row++)
            {
                if (gridData.CellModels[row * GridData.SideGridLength + rowIndex].CellValue != value)
                    return false;
            }
            return true;
        }
        
        private bool CheckDiagonal(GridData gridData, int strIndex, int rowIndex, CellValue value)
        {
            if (strIndex == rowIndex)
            {
                for (int i = 0; i < GridData.SideGridLength; i++)
                {
                    if (gridData.CellModels[i * GridData.SideGridLength + i].CellValue != value)
                        return false;
                }
                return true;
            }
            
            if (strIndex + rowIndex == GridData.SideGridLength - 1)
            {
                for (int i = 0; i < GridData.SideGridLength; i++)
                {
                    if (gridData.CellModels[i * GridData.SideGridLength + (GridData.SideGridLength - 1 - i)].CellValue != value)
                        return false;
                }
                return true;
            }
            
            return false;
        }
    }
} 
using _Project.Scripts.MiniGameModule.TicTacToePopup;
using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace _Project.Scripts.MiniGameModule
{
    public interface IGameValidator
    {
        bool CheckWin(GridData gridData, int strIndex, int rowIndex, CellValue value);
        bool CheckDraw(GridData gridData);
    }
} 
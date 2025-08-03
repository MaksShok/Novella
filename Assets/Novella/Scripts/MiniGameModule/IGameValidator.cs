using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public interface IGameValidator
    {
        bool CheckWin(GridData gridData, int strIndex, int rowIndex, CellValue value);
        bool CheckDraw(GridData gridData);
    }
} 
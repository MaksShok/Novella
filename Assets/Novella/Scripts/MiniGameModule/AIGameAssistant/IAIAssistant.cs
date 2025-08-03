using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.AIGameAssistant
{
    public interface IAIAssistant
    {
        (int strIndex, int rowIndex) GetBestMove(CellValue aiSymbol, CellValue playerSymbol);
    }
} 
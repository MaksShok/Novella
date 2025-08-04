using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace _Project.Scripts.MiniGameModule.AIGameAssistant
{
    public interface IAIAssistant
    {
        (int strIndex, int rowIndex) GetBestMove(CellValue aiSymbol, CellValue playerSymbol);
    }
} 
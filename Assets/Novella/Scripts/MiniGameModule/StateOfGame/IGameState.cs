using System;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.StateOfGame
{
    public interface IGameState
    {
        event Action<GameResult> OnGameEnded;
        event Action<int, int, CellValue> OnCellChanged;
        event Action<CellValue> OnPlayerChanged;
        
        void CellChangedInvokator(int arg1, int arg2, CellValue arg3);
        void PlayerChangedInvokator(CellValue cellValue);
        
        void EndGame(GameResult result);
        void ResetGame();
    }
    
    public enum GameResult
    {
        None,
        PlayerWin,
        NpcWin,
        Draw
    }
} 
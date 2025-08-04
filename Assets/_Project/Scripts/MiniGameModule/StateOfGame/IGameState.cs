using System;
using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace _Project.Scripts.MiniGameModule.StateOfGame
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
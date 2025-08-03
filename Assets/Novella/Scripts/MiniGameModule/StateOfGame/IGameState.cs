using System;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.StateOfGame
{
    public interface IReadOnlyGameState
    {
        event Action<CellValue> OnPlayerChanged;
        event Action<GameResult> OnGameEnded;
        event Action<int, int, CellValue> OnCellChanged;
        
        CellValue CurrentPlayer { get; }
        bool IsGameActive { get; }
        GameResult Result { get; }
    }
    
    public interface IGameState : IReadOnlyGameState
    {
        bool TryMakeMove(int strIndex, int rowIndex, CellValue value);
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
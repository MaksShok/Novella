using System;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.StateOfGame
{
    public interface IGameState
    {
        event Action<GameResult> OnGameEnded;
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
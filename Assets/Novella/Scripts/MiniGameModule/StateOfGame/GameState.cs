using System;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.StateOfGame
{
    public class GameState : IGameState
    {
        public event Action<GameResult> OnGameEnded;
        public event Action<int, int, CellValue> OnCellChanged;
        public event Action<CellValue> OnPlayerChanged;

        private readonly GameStateInfo _gameStateInfo;
        private readonly GridData _gridData;

        public GameState(GameStateInfo gameStateInfo, GridData gridData)
        {
            _gameStateInfo = gameStateInfo;
            _gridData = gridData;
        }

        public void EndGame(GameResult result)
        {
            _gameStateInfo.IsGameActive = false;
            _gameStateInfo.Result = result;
            OnGameEnded?.Invoke(result);
        }

        public void ResetGame()
        {
            _gridData.Reset();
            _gameStateInfo.CurrentPlayer = _gameStateInfo.PlayerSymbol;
            _gameStateInfo.IsGameActive = true;
            _gameStateInfo.Result = GameResult.None;
        }

        public void CellChangedInvokator(int arg1, int arg2, CellValue arg3)
        {
            OnCellChanged?.Invoke(arg1, arg2, arg3);
        }

        public void PlayerChangedInvokator(CellValue cellValue)
        {
            OnPlayerChanged?.Invoke(cellValue);
        }
    }
} 
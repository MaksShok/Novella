using System;
using _Project.Scripts.MiniGameModule.TicTacToePopup;
using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace _Project.Scripts.MiniGameModule.StateOfGame
{
    public class GameState : IGameState
    {
        private readonly GameStateInfo _gameStateInfo;
        private readonly GridData _gridData;
        
        public event Action<GameResult> OnGameEnded;
        public event Action<int, int, CellValue> OnCellChanged;
        public event Action<CellValue> OnPlayerChanged;
        
        public IReadOnlyGameStateInfo GameStateInfo => _gameStateInfo;

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
            _gameStateInfo.CurrentPlayer = _gameStateInfo.FirstPlayer;
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
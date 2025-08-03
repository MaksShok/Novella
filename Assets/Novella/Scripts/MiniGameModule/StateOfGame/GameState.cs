using System;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.StateOfGame
{
    public class GameState : IGameState
    {
        public event Action<CellValue> OnPlayerChanged;
        public event Action<GameResult> OnGameEnded;
        public event Action<int, int, CellValue> OnCellChanged;
        
        public CellValue CurrentPlayer { get; private set; }
        public bool IsGameActive { get; private set; }
        public GameResult Result { get; private set; }
        
        private readonly GridData _gridData;
        private readonly IGameValidator _validator;
        private readonly CellValue _playerSymbol;
        private readonly CellValue _npcSymbol;
        
        public GameState(GridData gridData, IGameValidator validator, 
            CellValue playerSymbol, CellValue npcSymbol, bool playerStartsFirst = true)
        {
            _gridData = gridData;
            _validator = validator;
            _playerSymbol = playerSymbol;
            _npcSymbol = npcSymbol;
            
            CurrentPlayer = playerStartsFirst ? _playerSymbol : _npcSymbol;
            IsGameActive = true;
            Result = GameResult.None;
        }
        
        public bool TryMakeMove(int strIndex, int rowIndex, CellValue value)
        {
            if (!IsGameActive || value != CurrentPlayer)
                return false;
                
            if (!_gridData.TryChangeCellValue(strIndex, rowIndex, value))
                return false;
                
            OnCellChanged?.Invoke(strIndex, rowIndex, value);
            
            if (_validator.CheckWin(_gridData, strIndex, rowIndex, value))
            {
                EndGame(value == _playerSymbol ? GameResult.PlayerWin : GameResult.NpcWin);
                return true;
            }
            
            if (_validator.CheckDraw(_gridData))
            {
                EndGame(GameResult.Draw);
                return true;
            }
            
            SwitchPlayer();
            return true;
        }
        
        public void ResetGame()
        {
            _gridData.Reset();
            CurrentPlayer = _playerSymbol;
            IsGameActive = true;
            Result = GameResult.None;
            OnPlayerChanged?.Invoke(CurrentPlayer);
        }
        
        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == _playerSymbol ? _npcSymbol : _playerSymbol;
            OnPlayerChanged?.Invoke(CurrentPlayer);
        }
        
        private void EndGame(GameResult result)
        {
            IsGameActive = false;
            Result = result;
            OnGameEnded?.Invoke(result);
        }
    }
} 
using Novella.Scripts.MiniGameModule.AIGameAssistant;
using Novella.Scripts.MiniGameModule.StateOfGame;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public class MoveStrategy
    {
        private readonly IReadOnlyGameStateInfo _gameStateInfo;
        private readonly GridData _gridData;
        private readonly IGameValidator _validator;
        private readonly IGameState _gameState;
        private readonly IAIAssistant _aiAssistant;
        
        private CellValue _playerSymbol;
        private CellValue _npcSymbol;
        
        public MoveStrategy(IReadOnlyGameStateInfo gameStateInfo, GridData gridData, 
            IGameValidator validator, IGameState gameState, IAIAssistant aiAssistant)
        {
            _gameStateInfo = gameStateInfo;
            _gridData = gridData;
            _validator = validator;
            _gameState = gameState;
            _aiAssistant = aiAssistant;

            _playerSymbol = _gameStateInfo.PlayerSymbol;
            _npcSymbol = _gameStateInfo.NPCSymbol;
        }
        
        public void MakePlayerMove(int strIndex, int rowIndex)
        {
            if (_gameStateInfo.CurrentPlayer == _playerSymbol)
            {
                TryMakeMove(strIndex, rowIndex, _playerSymbol);
            }
        }

        private void MakeAIMove()
        {
            var (strIndex, rowIndex) = _aiAssistant.GetBestMove(_gridData, _npcSymbol, _playerSymbol);
            if (strIndex >= 0 && rowIndex >= 0)
            {
                TryMakeMove(strIndex, rowIndex, _npcSymbol);
            }
        }
        
        private bool TryMakeMove(int strIndex, int rowIndex, CellValue cellValue)
        {
            if (!_gameStateInfo.IsGameActive || cellValue != _gameStateInfo.CurrentPlayer)
                return false;
                
            if (!_gridData.TryChangeCellValue(strIndex, rowIndex, cellValue))
                return false;

            _gameState.CellChangedInvokator(strIndex, rowIndex, cellValue);
            
            if (_validator.CheckWin(_gridData, strIndex, rowIndex, cellValue))
            {
                _gameState.EndGame(cellValue == _playerSymbol ? GameResult.PlayerWin : GameResult.NpcWin);
                return true;
            }
            
            if (_validator.CheckDraw(_gridData))
            {
                _gameState.EndGame(GameResult.Draw);
                return true;
            }
            
            SwitchPlayer();
            return true;
        }
        
        private void SwitchPlayer()
        {
            _gameStateInfo.SwitchPlayer();
            _gameState.PlayerChangedInvokator(_gameStateInfo.CurrentPlayer);
            
            if (_gameStateInfo.CurrentPlayer == _npcSymbol)
            {
                MakeAIMove();
            }
        }
    }
}
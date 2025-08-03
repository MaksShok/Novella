using System;
using Novella.Scripts.MiniGameModule.AIGameAssistant;
using Novella.Scripts.MiniGameModule.StateOfGame;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using UnityEngine;
using Zenject;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public class TicTacToeGameManager : MonoBehaviour
    {
        [Inject] private IGameState _gameState;
        [Inject] private IAIAssistant _aiService;
        [Inject] private GridData _gridData;
        
        [SerializeField] private CellValue _playerSymbol = CellValue.Cross;
        [SerializeField] private CellValue _aiSymbol = CellValue.Zero;
        [SerializeField] private bool _playerStartsFirst = true;
        
        private void Start()
        {
            SubscribeToEvents();
        }
        
        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }
        
        private void SubscribeToEvents()
        {
            _gameState.OnPlayerChanged += HandlePlayerChanged;
            _gameState.OnGameEnded += HandleGameEnded;
            _gameState.OnCellChanged += HandleCellChanged;
        }
        
        private void UnsubscribeFromEvents()
        {
            _gameState.OnPlayerChanged -= HandlePlayerChanged;
            _gameState.OnGameEnded -= HandleGameEnded;
            _gameState.OnCellChanged -= HandleCellChanged;
        }
        
        public void MakePlayerMove(int strIndex, int rowIndex)
        {
            if (_gameState.CurrentPlayer == _playerSymbol)
            {
                _gameState.TryMakeMove(strIndex, rowIndex, _playerSymbol);
            }
        }
        
        private void HandlePlayerChanged(CellValue newPlayer)
        {
            if (newPlayer == _aiSymbol && _gameState.IsGameActive)
            {
                MakeAIMove();
            }
        }
        
        private void MakeAIMove()
        {
            var (strIndex, rowIndex) = _aiService.GetBestMove(_gridData, _aiSymbol, _playerSymbol);
            if (strIndex >= 0 && rowIndex >= 0)
            {
                _gameState.TryMakeMove(strIndex, rowIndex, _aiSymbol);
            }
        }
        
        private void HandleGameEnded(GameResult result)
        {
            Debug.Log($"Game ended with result: {result}");
        }
        
        private void HandleCellChanged(int strIndex, int rowIndex, CellValue value)
        {
            Debug.Log($"Cell changed: ({strIndex}, {rowIndex}) = {value}");
        }
        
        public void ResetGame()
        {
            _gameState.ResetGame();
        }
    }
}
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
        [Inject] private IReadOnlyGameStateInfo _gameStateInfo;
        [Inject] private GridData _gridData;
        
        private CellValue _playerSymbol;
        private CellValue _npcSymbol;
        
        private void Start()
        {
            SubscribeToEvents();
            
            _playerSymbol = _gameStateInfo.PlayerSymbol;
            _npcSymbol = _gameStateInfo.NPCSymbol;
        }
        
        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        public void ResetGame()
        {
            _gridData.Reset();
            _gameState.ResetGame();
        }

        private void SubscribeToEvents()
        {
            _gameState.OnGameEnded += HandleGameEnded;
            _gameState.OnCellChanged += HandleCellChanged;
        }

        private void UnsubscribeFromEvents()
        {
            _gameState.OnGameEnded -= HandleGameEnded;
            _gameState.OnCellChanged -= HandleCellChanged;
        }

        private void HandleGameEnded(GameResult result)
        {
            Debug.Log($"Game ended with result: {result}");
        }

        private void HandleCellChanged(int strIndex, int rowIndex, CellValue value)
        {
            Debug.Log($"Cell changed: ({strIndex}, {rowIndex}) = {value}");
        }
    }
}
using Novella.Scripts.InstallModule;
using Novella.Scripts.MiniGameModule.StateOfGame;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using UnityEngine;
using Zenject;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public class TicTacToeGameManager : MonoBehaviour
    {
        [SerializeField] private TicTacToeGridView _gridViewPrefab;
        [SerializeField] private RectTransform _root;
        
        [Inject] private IGameState _gameState;
        [Inject] private GamePrefabFactory _gamePrefabFactory;

        private void Start()
        {
            var gridView = _gamePrefabFactory.InstantiatePrefab<TicTacToeGridView>(_gridViewPrefab, _root);
            gridView.InitialGamePopupModel(new TicTacToeGridModel());
            
            SubscribeToEvents();
        }
        
        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        public void ResetGame()
        {
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
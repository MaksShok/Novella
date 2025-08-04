using Novella.Scripts.Configs;
using Novella.Scripts.InstallModule;
using Novella.Scripts.MiniGameModule.StateOfGame;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using UnityEngine;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public class TicTacToeGameBootstrapper
    {
        private readonly RectTransform _uiRoot;
        private readonly IGameState _gameState;
        private readonly GamePrefabFactory _gamePrefabFactory;
        private readonly LevelConfig _config;

        public TicTacToeGameBootstrapper(RectTransform uiRoot, IGameState gameState, 
            GamePrefabFactory prefabFactory, LevelConfig config)
        {
            _uiRoot = uiRoot;
            _gameState = gameState;
            _gamePrefabFactory = prefabFactory;
            _config = config;
        }
        
        public void StartGame()
        {
            var gridViewPrefab = _config.UIConfig.GridViewPrefab;
            var gridView = _gamePrefabFactory.InstantiatePrefab<TicTacToeGridView>(gridViewPrefab, _uiRoot);
            
            gridView.InitialGamePopupModel(new TicTacToeGridModel());
            
            SubscribeToEvents();
        }

        public void ResetGame()
        {
            _gameState.ResetGame();
        }

        private void HandleGameEnded(GameResult result)
        {
            Debug.Log($"Game ended with result: {result}");
        }

        private void HandleCellChanged(int strIndex, int rowIndex, CellValue value)
        {
            Debug.Log($"Cell changed: ({strIndex}, {rowIndex}) = {value}");
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

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }
    }
}
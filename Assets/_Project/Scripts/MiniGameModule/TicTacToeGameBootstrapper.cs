using _Project.Scripts.Configs;
using _Project.Scripts.InstallModule;
using _Project.Scripts.MiniGameModule.StateOfGame;
using _Project.Scripts.MiniGameModule.TicTacToePopup;
using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;
using UnityEngine;

namespace _Project.Scripts.MiniGameModule
{
    public class TicTacToeGameBootstrapper
    {
        private readonly UIRoot _uiRoot;
        private readonly IGameState _gameState;
        private readonly GamePrefabFactory _gamePrefabFactory;
        private readonly LevelConfig _config;
        private readonly TicTacToeGridModel _gridModel;

        public TicTacToeGameBootstrapper(UIRoot uiRoot, IGameState gameState, 
            GamePrefabFactory prefabFactory, LevelConfig config)
        {
            _uiRoot = uiRoot;
            _gameState = gameState;
            _gamePrefabFactory = prefabFactory;
            _config = config;

            _gridModel = new TicTacToeGridModel(_gameState, gameState.GameStateInfo);
        }
        
        public void StartGame()
        {
            var gridViewPrefab = _config.UIConfig.GridViewPrefab;
            var gridView = _gamePrefabFactory.InstantiatePrefab<TicTacToeGridView>(gridViewPrefab, _uiRoot.PopupsRoot);
            
            gridView.InitialGridModel(_gridModel);
            
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
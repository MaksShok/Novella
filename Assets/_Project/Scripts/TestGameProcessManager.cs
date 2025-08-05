using _Project.Scripts.ConditionModule.Task;
using _Project.Scripts.Configs;
using _Project.Scripts.InstallModule;
using _Project.Scripts.InventoryModule;
using _Project.Scripts.MiniGameModule;
using _Project.Scripts.MiniGameModule.StateOfGame;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class TestGameProcessManager : MonoBehaviour
    {
        [SerializeField] private InventoryItem _key;
        
        [Inject] private TicTacToeGameBootstrapper _ticTacToeBootstrapper;
        [Inject] private LevelConfig _levelConfig;
        [Inject] private IGameState _ticTacToGameState;

        [Inject] private CurrentTaskProvider _currentTaskProvider;
        
        [Inject] private InventoryModel _inventoryModel;
        [Inject] private UIRoot _uiRoot;
        [Inject] private GamePrefabFactory _gamePrefabFactory;

        private BooleanTask _ticTacToeTask;

        private void Start()
        {
            //InventoryTestStart();
            TicTacToeGameStart();
        }

        private void InventoryTestStart()
        {
            _inventoryModel.AddItem(_key); //Test
            
            var inventoryPrefab = _levelConfig.UIConfig.InventoryView;
            
            var inventory = _gamePrefabFactory
                .InstantiatePrefab<InventoryView>(inventoryPrefab, _uiRoot.HUDRoot);
            
            inventory.InitializeInventoryModel(_inventoryModel);
        }

        private void TicTacToeGameStart()
        {
            _ticTacToeTask = new BooleanTask(_levelConfig.TasksInfo[0]);
            
            _ticTacToGameState.OnGameEnded += CompleteTicTacToeTask;
            _ticTacToeTask.Status.OnValueChange += OnTicTacToeTaskComplete;
            
            _ticTacToeBootstrapper.StartGame();
        }
            

        private void CompleteTicTacToeTask(GameResult gameResult)
        {
            if (gameResult == GameResult.PlayerWin)
                _ticTacToeTask.SetTaskComplete();
        }

        private void OnTicTacToeTaskComplete(bool status)
        {
            if (status)
                Debug.Log("Quest Completed !!!");
        }
    }
}
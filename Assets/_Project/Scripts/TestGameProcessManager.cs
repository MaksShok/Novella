using _Project.Scripts.ConditionModule.Task;
using _Project.Scripts.Configs;
using _Project.Scripts.MiniGameModule;
using _Project.Scripts.MiniGameModule.StateOfGame;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class TestGameProcessManager : MonoBehaviour
    {
        private TicTacToeGameBootstrapper _ticTacToeBootstrapper;
        private LevelConfig _levelConfig;
        private IGameState _ticTacToGameState;

        private BooleanTask _task;

        [Inject]
        private void Constructor(TicTacToeGameBootstrapper ticTacToeBootstrapper, LevelConfig levelConfig,
            IGameState ticTacToGameState)
        {
            _ticTacToeBootstrapper = ticTacToeBootstrapper;
            _levelConfig = levelConfig;
            _ticTacToGameState = ticTacToGameState;
        }

        private void Start()
        {
            _task = new BooleanTask(_levelConfig.TasksInfo[0]);
            
            _ticTacToGameState.OnGameEnded += CompleteTask;
            _task.Status.OnValueChange += OnQuestComplete;
            
            _ticTacToeBootstrapper.StartGame();
        }

        private void CompleteTask(GameResult gameResult)
        {
            if (gameResult == GameResult.PlayerWin)
                _task.SetTaskComplete();
        }

        private void OnQuestComplete(bool status)
        {
            if (status)
                Debug.Log("Quest Completed !!!");
        }
    }
}
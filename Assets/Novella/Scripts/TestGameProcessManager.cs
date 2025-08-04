using System.Collections.Generic;
using Novella.Scripts.Configs;
using Novella.Scripts.MiniGameModule;
using Novella.Scripts.MiniGameModule.StateOfGame;
using Novella.Scripts.QuestModule;
using Novella.Scripts.QuestModule.Task;
using UnityEngine;
using Zenject;

namespace Novella.Scripts
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
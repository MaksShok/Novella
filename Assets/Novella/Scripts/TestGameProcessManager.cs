using System;
using Novella.Scripts.Configs;
using Novella.Scripts.MiniGameModule;
using UnityEngine;
using Zenject;

namespace Novella.Scripts
{
    public class TestGameProcessManager : MonoBehaviour
    {
        private TicTacToeGameBootstrapper _ticTacToeBootstrapper;
        private LevelConfig _levelConfig;
        
        [Inject]
        private void Constructor(TicTacToeGameBootstrapper ticTacToeBootstrapper, LevelConfig levelConfig)
        {
            _ticTacToeBootstrapper = ticTacToeBootstrapper;
            _levelConfig = levelConfig;
        }

        private void Start()
        {
            _ticTacToeBootstrapper.StartGame();
        }
    }
}
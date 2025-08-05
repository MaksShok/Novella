using System;
using _Project.Scripts.MiniGameModule.StateOfGame;
using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;
using _Project.Scripts.Misc;

namespace _Project.Scripts.MiniGameModule.TicTacToePopup
{
    public class TicTacToeGridModel
    {
        private readonly IGameState _gameState;
        private readonly IReadOnlyGameStateInfo _gameInfo;

        public IReadOnlyReactiveProperty<string> WhoIsStepText => _whoIsStepText;
        private ReactiveProperty<string> _whoIsStepText = new (String.Empty);
        
        public TicTacToeGridModel(IGameState gameState, IReadOnlyGameStateInfo gameInfo)
        {
            _gameState = gameState;
            _gameInfo = gameInfo;
            _gameState.OnPlayerChanged += UpdatePlayerCellText;
            _gameState.OnGameEnded += UpdateGameResultText;
            
            UpdatePlayerCellText(_gameInfo.CurrentPlayer);
        }

        public void ResetGameRequest()
        {
            _gameState.ResetGame();
            UpdatePlayerCellText(_gameInfo.CurrentPlayer);
        }

        private void UpdatePlayerCellText(CellValue cellValue)
        {
            if (cellValue == _gameInfo.PlayerSymbol)
                _whoIsStepText.Value = "Ваш ход";
            
            else if (cellValue == _gameInfo.NPCSymbol)
                _whoIsStepText.Value = "Ходит ИИ...";
        }

        private void UpdateGameResultText(GameResult result)
        {
            if (result == GameResult.PlayerWin)
                _whoIsStepText.Value = "Вы выйграли!";
            
            else if (result == GameResult.NpcWin)
                _whoIsStepText.Value = "Вы проиграли";
            
            else if (result == GameResult.Draw)
                _whoIsStepText.Value = "Ничья - победила дружба!";
        }
    }
}
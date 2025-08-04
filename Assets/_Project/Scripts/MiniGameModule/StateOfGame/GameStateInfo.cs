using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace _Project.Scripts.MiniGameModule.StateOfGame
{
    public interface IReadOnlyGameStateInfo
    {
        public CellValue CurrentPlayer { get; }
        public CellValue PlayerSymbol { get; }
        public CellValue NPCSymbol { get; }
        
        public bool IsGameActive { get; }
        public GameResult Result { get; }

        void SwitchPlayer();
    }
        
    public class GameStateInfo : IReadOnlyGameStateInfo
    {
        public CellValue CurrentPlayer { get; set; }
        public CellValue PlayerSymbol { get; }
        public CellValue NPCSymbol { get; }
        
        public bool IsGameActive { get; set; }
        public GameResult Result { get; set; }
        
        public GameStateInfo(CellValue playerSymbol, CellValue npcSymbol, bool playerStartsFirst = true)
        {
            CurrentPlayer = playerStartsFirst ? playerSymbol : npcSymbol;
            PlayerSymbol = playerSymbol;
            NPCSymbol = npcSymbol;

            IsGameActive = true;
            Result = GameResult.None;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == PlayerSymbol ? NPCSymbol : PlayerSymbol;
        }
    }
}
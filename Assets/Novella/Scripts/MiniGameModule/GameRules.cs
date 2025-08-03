using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;
using UnityEngine;

namespace Novella.Scripts.MiniGameModule
{
    public class GameRules
    {
        public static CellValue PlayerCellValue = CellValue.Cross;
        public static CellValue NpcCellValue = CellValue.Zero;

        public static bool PlayerStepping => _playerStepping;
        private static bool _playerStepping;
        
        public GameRules(CellValue playerCellValue, CellValue npcCellValue, 
            bool yourStepIsFirst)
        {
            PlayerCellValue = playerCellValue;
            NpcCellValue = npcCellValue;
            _playerStepping = yourStepIsFirst;
        }

        public static void ChangeStepStatus()
        {
            _playerStepping = !_playerStepping;
        }
    }
}
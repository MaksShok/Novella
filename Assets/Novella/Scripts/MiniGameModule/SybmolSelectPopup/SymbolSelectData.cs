using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.SybmolSelectPopup
{
    public class SymbolSelectData
    {
        public CellValue PlayerCellValue { get; }
        public CellValue NpcCellValue { get; }

        public SymbolSelectData(CellValue playerCellValue, CellValue npcCellValue)
        {
            PlayerCellValue = playerCellValue;
            NpcCellValue = npcCellValue;
        }
    }
}
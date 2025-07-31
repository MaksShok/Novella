using Novella.Scripts.MiniGameModule.Cell;
using Novella.Scripts.MiniGameModule.GamePopup;
using Novella.Scripts.MiniGameModule.StartUpPopup;
using UnityEngine;

namespace Novella.Scripts.MiniGameModule
{
    public class MiniGameManager: MonoBehaviour
    {
        [SerializeField] private StartUpMiniGamePopup _startUpGamePopup;
        [SerializeField] private MiniGamePopup _gamePopup;
        
        public CellValue PlayerCellValue { get; private set; }
        public CellValue NpcCellValue { get; private set; }

        public void StartGame()
        {
            
        }
    }
}
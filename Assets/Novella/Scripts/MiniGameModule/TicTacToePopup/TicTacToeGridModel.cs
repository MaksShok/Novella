using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;
using UnityEngine;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup
{
    public class TicTacToeGridModel
    {
        private readonly GridData _gridData;
        
        public string WhoIsStepText => _whoIsStepText;
        private string _whoIsStepText;

        public TicTacToeGridModel(GridData gridData)
        {
            _gridData = gridData;
        }

        public void MakeMove(int strIndex, int rowIndex, CellValue cellValue)
        {
            if (_gridData.TryChangeCellValue(strIndex, rowIndex, cellValue))
            {
                
            }
            else
            {
                Debug.LogErrorFormat("Ход не доступен или не верный!!!");
            }
        }
    }
}
using System.Collections.Generic;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Novella.Scripts.MiniGameModule.TicTacToePopup
{
    public class GridCellGenerator: MonoBehaviour
    {
        [SerializeField] private GridCellView _gameCellPrefab;
        [SerializeField] private GridLayoutGroup _root;

        [Inject]
        private GridData _gridData;
        
        private int _cellsInGrid = GridData.CellsInGrid;

        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int i = 0; i < _cellsInGrid; i++)
            { 
                GridCellView gameCellView = Instantiate(_gameCellPrefab, _root.transform);
                GridCellModel cellModel = _gridData.CellModels[i];
                
                gameCellView.InitialCellModel(cellModel);
            }
        }
    }
}
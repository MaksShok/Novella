using System.Collections.Generic;
using System.Linq;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule.AIGameAssistant
{
    public class AIAssistant : IAIAssistant
    {
        private readonly IGameValidator _validator;

        private List<GridCellModel> _availablePositions;
        

        public AIAssistant(IGameValidator validator)
        {
            _validator = validator;
        }
        
        public (int strIndex, int rowIndex) GetBestMove(GridData gridData, CellValue aiSymbol, CellValue playerSymbol)
        {
            var availableMoves = GetAvailableMoves(gridData);
            
            if (!availableMoves.Any())
                return (-1, -1);
            
            var bestMove = FindWinningMove(gridData, aiSymbol, availableMoves);
            if (bestMove.HasValue)
                return bestMove.Value;
            
            bestMove = FindWinningMove(gridData, playerSymbol, availableMoves);
            if (bestMove.HasValue)
                return bestMove.Value;
            
            return GetRandomMove(availableMoves);
        }
        
        private List<(int strIndex, int rowIndex)> GetAvailableMoves(GridData gridData)
        {
            var moves = new List<(int strIndex, int rowIndex)>();
            
            for (int str = 0; str < GridData.SideGridLength; str++)
            {
                for (int row = 0; row < GridData.SideGridLength; row++)
                {
                    int index = str * GridData.SideGridLength + row;
                    if (gridData.CellModels[index].CellValue == CellValue.None)
                    {
                        moves.Add((str, row));
                    }
                }
            }
            
            return moves;
        }
        
        private (int strIndex, int rowIndex)? FindWinningMove(GridData gridData, CellValue symbol, 
            List<(int strIndex, int rowIndex)> availableMoves)
        {
            foreach (var move in availableMoves)
            {
                var tempGrid = CreateTempGrid(gridData);
                tempGrid.TryChangeCellValue(move.strIndex, move.rowIndex, symbol);
                
                if (_validator.CheckWin(tempGrid, move.strIndex, move.rowIndex, symbol))
                {
                    return move;
                }
            }
            
            return null;
        }

        private (int strIndex, int rowIndex) GetRandomMove(List<(int strIndex, int rowIndex)> availableMoves)
        {
            var random = new System.Random();
            int index = random.Next(availableMoves.Count);
            return availableMoves[index];
        }
        
        private GridData CreateTempGrid(GridData original)
        {
            var tempGrid = new GridData();
            for (int i = 0; i < original.CellModels.Count; i++)
            {
                if (original.CellModels[i].CellValue != CellValue.None)
                {
                    int strIndex = i / GridData.SideGridLength;
                    int rowIndex = i % GridData.SideGridLength;
                    tempGrid.TryChangeCellValue(strIndex, rowIndex, original.CellModels[i].CellValue);
                }
            }
            return tempGrid;
        }
    }
} 
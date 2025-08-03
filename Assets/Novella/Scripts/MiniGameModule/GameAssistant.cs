using System.Collections.Generic;
using System.Linq;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;

namespace Novella.Scripts.MiniGameModule
{
    public class GameAssistant
    {
        private readonly GridData _gridData;
        private readonly CellValue _playerCellValue;
        private readonly CellValue _npcCellValue;

        private List<GridCellModel> _npcCells = new(5);
        private List<GridCellModel> _playerCells = new(5);
        private List<GridCellModel> _freeCells;

        public GameAssistant(GridData gridData)
        {
            _gridData = gridData;
            _playerCellValue = GameRules.PlayerCellValue;
            _npcCellValue = GameRules.NpcCellValue;

            _freeCells = new List<GridCellModel>(_gridData.CellModels); // копируем все модили ячеек
            
        }
        
        

        private void DoMove()
        {
            int strIndex;
            int rowIndex;

            if (GameRules.PlayerStepping)
                return;

            GridCellModel targetPosition;

            if (TryDetectWinPosition(_npcCells, out targetPosition))
            {
                
            }
            else if (TryDetectWinPosition(_playerCells, out targetPosition))
            {
                
            }
            else
            {
                
            }
        }
        
        

        private bool TryDetectWinPosition(List<GridCellModel> positions, out GridCellModel model)
        {
            model = null;

            if (positions == null || positions.Count < 3)
                return false;

            // Группируем позиции по строкам, столбцам и диагоналям
            var rows = new Dictionary<int, List<GridCellModel>>();
            var cols = new Dictionary<int, List<GridCellModel>>();
            var diagonals = new Dictionary<int, List<GridCellModel>>();

            // Распределяем ячейки по группам
            foreach (var position in positions)
            {
                // Группировка по строкам
                if (!rows.ContainsKey(position.StrIndex))
                    rows[position.StrIndex] = new List<GridCellModel>();
                rows[position.StrIndex].Add(position);

                // Группировка по столбцам
                if (!cols.ContainsKey(position.RowIndex))
                    cols[position.RowIndex] = new List<GridCellModel>();
                cols[position.RowIndex].Add(position);

                // Группировка по главной диагонали (строка == столбец)
                if (position.StrIndex == position.RowIndex)
                {
                    if (!diagonals.ContainsKey(0))
                        diagonals[0] = new List<GridCellModel>();
                    diagonals[0].Add(position);
                }

                // Группировка по побочной диагонали (строка + столбец == 2 для 3x3)
                if (position.StrIndex + position.RowIndex == 2)
                {
                    if (!diagonals.ContainsKey(1))
                        diagonals[1] = new List<GridCellModel>();
                    diagonals[1].Add(position);
                }
            }

            // Проверяем строки
            foreach (var row in rows)
            {
                if (row.Value.Count >= 3)
                {
                    // Найдена выигрышная строка
                    model = row.Value[0]; // Возвращаем первую ячейку из выигрышной линии
                    return true;
                }
            }

            // Проверяем столбцы
            foreach (var col in cols)
            {
                if (col.Value.Count >= 3)
                {
                    // Найден выигрышный столбец
                    model = col.Value[0]; // Возвращаем первую ячейку из выигрышной линии
                    return true;
                }
            }

            // Проверяем диагонали
            foreach (var diagonal in diagonals)
            {
                if (diagonal.Value.Count >= 3)
                {
                    // Найдена выигрышная диагональ
                    model = diagonal.Value[0]; // Возвращаем первую ячейку из выигрышной линии
                    return true;
                }
            }

            return false;
        }
    }
}
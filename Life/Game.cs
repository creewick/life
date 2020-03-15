using System.Collections.Generic;
using System.Linq;

namespace Life
{
    /* Ограничения на код:
     * 
     * 1. Не больше 3 строк в методе
     * 2. Без использования циклов
     * 3. Без использования условных операторов
     * 
     */
    public class Game
    {
        public readonly HashSet<(int x, int y)> AliveCells;
        private readonly HashSet<(int x, int y)> neighbours =
            new HashSet<(int x, int y)>
        {
            (-1, 1), (0, 1), (1, 1),
            (-1, 0), /****/  (1, 0),
            (-1,-1), (0,-1), (1,-1)
        };

        public Game(HashSet<(int x, int y)> aliveCells)
        {
            AliveCells = aliveCells;
        }

        public Game GetNextState()
        {
            return new Game(GetNextStateCells());
        }

        private HashSet<(int x, int y)> GetNextStateCells()
        {
            return GetOldAliveCells()
                .Union(GetNewAliveCells())
                .ToHashSet();
        }

        private IEnumerable<(int x, int y)> GetOldAliveCells()
        {
            return AliveCells
                .Where(KeepCellAlive);
        }

        private IEnumerable<(int x, int y)> GetNewAliveCells()
        {
            return AliveCells
                .SelectMany(GetNeighbours)
                .Where(GiveLife);
        }

        private bool GiveLife((int x, int y) cell)
        {
            return GetAliveNeighboursCount(cell) == 3;
        }

        private bool KeepCellAlive((int x, int y) cell)
        {
            var aliveNeighboursCount = GetAliveNeighboursCount(cell);

            return aliveNeighboursCount == 2 || aliveNeighboursCount == 3;
        }

        private int GetAliveNeighboursCount((int x, int y) cell)
        {
            return GetNeighbours(cell)
                .Intersect(AliveCells)
                .Count();
        }

        private IEnumerable<(int x, int y)> GetNeighbours((int x, int y) cell)
        {
            return neighbours
                .Select(neighbour =>
                    (neighbour.x + cell.x, neighbour.y + cell.y));
        }
    }
}
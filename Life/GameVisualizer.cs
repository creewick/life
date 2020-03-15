using System;
using System.Linq;
using System.Text;

namespace Life
{
    public static class GameVisualizer
    {
        public static string Visualize(Game game)
        {
            var xMin = game.AliveCells.Min(p => p.x);
            var xMax = game.AliveCells.Max(p => p.x);
            var yMin = game.AliveCells.Min(p => p.y);
            var yMax = game.AliveCells.Max(p => p.y);
            var builder = new StringBuilder();

            for (var y = yMin; y <= yMax; y++)
            {
                for (var x = xMin; x <= xMax; x++)
                {
                    builder.Append(game.AliveCells.Contains((x, y))
                        ? '#'
                        : ' ');
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
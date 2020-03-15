using System;
using System.Threading;

namespace Life
{
    public class Program
    {
        public static void Main()
        {
            var game = GameExamples.Spaceship;
            
            while (true)
            {
                var visualization = GameVisualizer.Visualize(game);
                game = game.GetNextState();
                Console.Clear();
                Console.WriteLine(visualization);
                
                Thread.Sleep(100);                
            }
        }
    }
}
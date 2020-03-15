using System;
using System.Collections.Generic;

namespace Life
{
    public static class GameExamples
    {
        public static Game Parse(string field)
        {
            var aliveCells = new HashSet<(int x, int y)>();

            var rows = field.Split(Environment.NewLine);
            
            for (var y = 0; y < rows.Length; y++)
                for (var x = 0; x < rows[y].Length; x++)
                    if (rows[y][x] == '#')
                        aliveCells.Add((x, y));

            return new Game(aliveCells);
        }

        public static Game Blinker = Parse("###");

        public static Game Toad = Parse(@"
            ###
           ###
        ");
        
        public static Game Beacon = Parse(@"
            ##
            #
               #
              ##
        ");

        public static Game Pulsar = Parse(@"
              ###   ###

            #    # #    #
            #    # #    #
            #    # #    #
              ###   ###

              ###   ###
            #    # #    #
            #    # #    #
            #    # #    #

              ###   ###
        ");

        public static Game IColumn = Parse(@"
            ###
             #
             #
            ###

            ###
            ###

            ###
             #
             #
            ###
        ");

        public static Game Glider = Parse(@"
            ##   #
            ##    #
                ###
        ");

        public static Game Spaceship = Parse(@"
            ##  #  #
            ##      #
                #   #
                 ####
        ");
    }
}
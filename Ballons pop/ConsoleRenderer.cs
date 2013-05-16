using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    static class ConsoleRenderer
    {
        // method extracted
        // matrix -> playground
        // GetLongLength -> GetLength
        // i -> row
        // j -> col
        public static void DrаwPlayground(Playground playground)
        {
            int rows = playground.Height;
            int columns = playground.Width;

            DrawFirstRow(columns);
            DrawHorizontalBorder(columns);

            for (byte row = 0; row < rows; row++)
            {
                Console.Write(row + " | ");
                DrawRowContent(playground, columns, row);
                Console.WriteLine("| ");
            }

            DrawHorizontalBorder(columns);
        }

        // method extracted
        public static void DrawRowContent(Playground playground, int columns, byte row)
        {
            for (byte col = 0; col < columns; col++)
            {
                if (playground[row, col] == 0)
                {
                    Console.Write("  ");
                    continue;
                }

                Console.Write(playground[row, col] + " ");
            }
        }

        // method extracted
        public static void DrawFirstRow(int columns)
        {
            Console.Write("    ");
            for (byte column = 0; column < columns; column++)
            {
                Console.Write(column + " ");
            }

            Console.WriteLine();
        }

        // method extracted
        public static void DrawHorizontalBorder(int columns)
        {
            Console.Write("   ");     //some trinket stuff again
            for (byte column = 0; column < columns * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Draws the top scores chart
        /// </summary>
        /// <param name="chart">The chart to draw</param>
        public static void DrawTopScoresChart(TopScoresChart chart)
        {
            Console.WriteLine("Top {0} scores:", chart.TopPlayers.Length);
            Console.WriteLine(chart.ToString());
        }
    }
}

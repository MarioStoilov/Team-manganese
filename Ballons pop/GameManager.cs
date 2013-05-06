using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    class GameManager
    {
        //TODO: implement the methods for managing the game
       
        // static void Main mast be in ConsoleInterface
        // temp - > userInput ??
        //else added

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = Playground.GeneratePlayground(5, 10);

            DrowPlayground(matrix);
            string temp = null;
            int userMoves = 0;
            while (temp != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                temp = Console.ReadLine();
                temp = temp.ToUpper().Trim();

                switch (temp)
                {
                    case "RESTART":
                        matrix = Playground.GeneratePlayground(5, 10);
                        DrowPlayground(matrix);
                        userMoves = 0;
                        break;

                    case "TOP":
                        klasacia.sortAndPrintChartFive(topFive);
                        break;

                    default:
                        if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(temp[0].ToString());
                            if (userRow > 4)
                            {
                                Console.WriteLine("Wrong input! Try Again ! ");
                                continue;
                            }
                            userColumn = int.Parse(temp[2].ToString());

                            if (Playground.IsEmptyCell(matrix, userRow, userColumn))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }
                            else
                            {
                                Playground.VisitCell(matrix, userRow, userColumn);
                            }

                            userMoves++;
                            if (Playground.ReorderPlayground(matrix))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (topFive.SignIfSkilled(userMoves))
                                {
                                    klasacia.sortAndPrintChartFive(topFive);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                matrix = Playground.GeneratePlayground(5, 10);
                                userMoves = 0;
                            }

                            DrowPlayground(matrix);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try Again! ");
                            break;
                        }
                }
            }
            Console.WriteLine("Good Bye! ");
        }
  
        // method extracted
        // matrix -> playground
        // GetLongLength -> GetLength
        // i -> row
        // j -> col
        private static void DrowPlayground(byte[,] playground)
        {
            int rows = playground.GetLength(0);
            int columns = playground.GetLength(1);

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
        private static void DrawRowContent(byte[,] playground, int columns, byte row)
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
        private static void DrawFirstRow(int columns)
        {
            Console.Write("    ");
            for (byte column = 0; column < columns; column++)
            {
                Console.Write(column + " ");
            }

            Console.WriteLine();
        }

        // method extracted
        private static void DrawHorizontalBorder(int columns)
        {
            Console.Write("   ");     //some trinket stuff again
            for (byte column = 0; column < columns * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}

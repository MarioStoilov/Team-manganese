using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    class GameManager
    {
        //TODO: implement the methods for managing the game


        // for change 
        static bool doit(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }
                }

                for (int k = columnLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
                    }
                }
            }
            return isWinner;
        }

        // static void Main mast be in ConsoleInterface
        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = Playground.GeneratePlayground(5, 10);

            Console.Write("    ");
            for (byte column = 0; column < matrix.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");
            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < matrix.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");
                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");     //some trinket stuff again
            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
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
                        Console.Write("    ");
                        for (byte column = 0; column < matrix.GetLongLength(1); column++)
                        {
                            Console.Write(column + " ");
                        }

                        Console.Write("\n   ");
                        for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                        {
                            Console.Write("-");
                        }

                        Console.WriteLine();

                        for (byte i = 0; i < matrix.GetLongLength(0); i++)
                        {
                            Console.Write(i + " | ");
                            for (byte j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 0)
                                {
                                    Console.Write("  ");
                                    continue;
                                }

                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.Write("| ");
                            Console.WriteLine();
                        }

                        Console.Write("   ");     //some trinket stuff again
                        for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
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
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }
                            userColumn = int.Parse(temp[2].ToString());

                            if (Playground.change(matrix, userRow, userColumn))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }
                            userMoves++;
                            if (doit(matrix))
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
                            Console.Write("    ");
                            for (byte column = 0; column < matrix.GetLongLength(1); column++)
                            {
                                Console.Write(column + " ");
                            }

                            Console.Write("\n   ");
                            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                            {
                                Console.Write("-");
                            }

                            Console.WriteLine();

                            for (byte i = 0; i < matrix.GetLongLength(0); i++)
                            {
                                Console.Write(i + " | ");
                                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                                {
                                    if (matrix[i, j] == 0)
                                    {
                                        Console.Write("  ");
                                        continue;
                                    }

                                    Console.Write(matrix[i, j] + " ");
                                }
                                Console.Write("| ");
                                Console.WriteLine();
                            }

                            Console.Write("   ");     //some trinket stuff again
                            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                            {
                                Console.Write("-");
                            }
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            break;
                        }


                }
            }
            Console.WriteLine("Good Bye! ");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    class GameManager
    {
        //TODO: implement the methods for managing the game
        // 1. The main method should not be here
        // 2. The current main method should be split into smaller ones
        // 3. Refactor the code
        // 
        // temp - > userInput ??
        //else added

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = Playground.GeneratePlayground(5, 10, 4);

            ConsoleRenderer.DrаwPlayground(matrix);
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
                        matrix = Playground.GeneratePlayground(5, 10, 4);
                        ConsoleRenderer.DrаwPlayground(matrix);
                        userMoves = 0;
                        break;

                    case "TOP":
                        TopScoresChart.sortAndPrintChartFive(topFive);
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

                            if (Playground.IsPositionEmpty(matrix, userRow, userColumn))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }
                            else
                            {
                                Playground.PopAtPosition(matrix, userRow, userColumn);
                            }

                            userMoves++;
                            Playground.ReorderPlayground(matrix);
                            if (Playground.IsPlaygroundEmpty(matrix))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (topFive.SignIfTopScoreArchived(userMoves))
                                {
                                    TopScoresChart.sortAndPrintChartFive(topFive);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                matrix = Playground.GeneratePlayground(5, 10, 4);
                                userMoves = 0;
                            }

                            ConsoleRenderer.DrаwPlayground(matrix);
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
  
        
    }
}

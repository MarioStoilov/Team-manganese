using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    class Program
    {
        static void Main(string[] args)
        {
            TopScoresChart topFive = new TopScoresChart(5);
            GameManager gameManager = new GameManager();

            ConsoleRenderer.DrаwPlayground(gameManager.PlayGround);
            string userInput = null;
            while (userInput != "EXIT")
            {
                userInput = ConsoleInterface.RequestInput();

                switch (userInput)
                {
                    case "RESTART":
                        RestartGame(ref gameManager, ref gameManager.PlayGround);
                        break;

                    case "TOP":
                        ConsoleRenderer.DrawTopScoresChart(topFive);
                        break;

                    default:
                        if (ConsoleInterface.IsValidInput(userInput))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(userInput[0].ToString());
                            userColumn = int.Parse(userInput[2].ToString());

                            if (!gameManager.PlayGround.IsOnPlayground(userRow, userColumn))
                            {
                                Console.WriteLine("Invalid playground coordinates! Please try again");
                                continue;
                            }

                            if (gameManager.PlayGround.IsPositionEmpty(userRow, userColumn))
                            {
                                Console.WriteLine("Cannot pop missing ballon!");
                                continue;
                            }
                            else
                            {
                                gameManager.PopAtPosition(userRow, userColumn);
                            }

                            gameManager.PlayGround.ReorderPlayground();
                            if (gameManager.PlayGround.IsPlaygroundEmpty())
                            {
                                EndGame(topFive, ref gameManager, ref gameManager.PlayGround);
                            }

                            ConsoleRenderer.DrаwPlayground(gameManager.PlayGround);
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

        private static void EndGame(TopScoresChart topFive, ref GameManager gameManager, ref Playground playground)
        {
            Console.WriteLine("Gratz ! You completed it in {0} moves.", gameManager.UserMoves);
            if (topFive.CheckIfHighScoreIsAchieved(gameManager.UserMoves))
            {
                TopScoresChartEntry newTopScore = ConsoleInterface.RequestInputForScoreBoard(gameManager.UserMoves);
                topFive.AddScore(newTopScore);
            }
            else
            {
                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
            }
            playground = new Playground(5, 10, 4);
            gameManager = new GameManager();
        }

        private static void RestartGame(ref GameManager gameManager, ref Playground playground)
        {
            playground = new Playground(5, 10, 4);
            ConsoleRenderer.DrаwPlayground(playground);
            gameManager = new GameManager();
        }
    }
}

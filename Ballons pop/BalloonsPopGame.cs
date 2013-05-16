using System;
using System.Linq;

namespace BalloonsPop
{
    class BalloonsPopGame
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
                       gameManager = RestartGame(); 
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
                                gameManager = EndGame(topFive, gameManager);
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

        private static GameManager EndGame(TopScoresChart topFive, GameManager gameManager)
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

            return new GameManager();
        }

        private static GameManager RestartGame()
        {
            return new GameManager();
        }
    }
}

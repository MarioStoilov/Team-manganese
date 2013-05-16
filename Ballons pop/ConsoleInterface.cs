using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    class ConsoleInterface
    {
        //TODO: implement methods for the user to comunicate with the game trhough the console
        // 1. All game output should be here. The field rendering is an exclusion
        // 2. All user input should be handled by this class

        public static TopScoresChartEntry RequestInputForScoreBoard(int score)
        {
            Console.Write("Type in your name: ");
            string topScoreUser = Console.ReadLine();
            return new TopScoresChartEntry(score, topScoreUser);
        }

        public static string RequestInput()
        {
            string userInput = null;
            Console.WriteLine("Enter a row and column: ");
            userInput = Console.ReadLine();
            userInput = userInput.ToUpper().Trim();

            return userInput;
        }

        public static bool IsValidInput(string userInput)
        {
            return (userInput.Length == 3) &&
                   (userInput[0] >= '0' && userInput[0] <= '9') &&
                   (userInput[2] >= '0' && userInput[2] <= '9') &&
                   (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ',');
        }

    }
}

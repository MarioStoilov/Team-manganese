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

    }
}

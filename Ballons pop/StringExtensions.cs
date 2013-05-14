using System;

namespace BalloonsPop
{
    static class StringExtensions
    {
        //TODO: This class is completely wrong. It serves to draw the top scores chart (which should be in the Console interface class)
        // and calculates wether the current score should enter the chart (which should be done by the game manager or the chart itself)
        // this needs to be split amongs the right classes and then removed

        public static bool SignIfTopScoreArchived(this string[,] chart, int points)
        {
            bool topScoreArchived = false;
            int topScore = 0;
            int topScoreChartPosition = 0;
            for (int i = 0; i < 5; i++)
            { 
                if (chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string topScoreUser = Console.ReadLine();
                    chart[i, 0] = points.ToString();
                    chart[i, 1] = topScoreUser;
                    topScoreArchived = true;
                    break;
                }
            }
            if (topScoreArchived == false) 
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(chart[i, 0]) > topScore)
                    {
                        topScoreChartPosition = i;
                        topScore = int.Parse(chart[i, 0]);
                    }
                }
            }
            if (points < topScore && topScoreArchived == false) 
            {
                Console.WriteLine("Type in your name.");
                string topScoreUser = Console.ReadLine();
                chart[topScoreChartPosition, 0] = points.ToString();
                chart[topScoreChartPosition, 1] = topScoreUser;
                topScoreArchived = true;
            }
            return topScoreArchived;
        }
    }
}
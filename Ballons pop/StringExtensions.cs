using System;

namespace BalloonsPop
{
    static class StringExtensions
    {
        //public override string ToString()
        //{
        //    return string.Format("");
        //}

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
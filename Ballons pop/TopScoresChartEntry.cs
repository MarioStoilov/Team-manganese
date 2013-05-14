using System;
using System.Collections.Generic;

namespace BalloonsPop
{
    public class TopScoresChartEntry : IComparable<TopScoresChartEntry>
    {
        public int Value;
        public string Name;

        public TopScoresChartEntry(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int CompareTo(TopScoresChartEntry other)
        {
            if (other==null)
            {
                return -1;
            }
            return Value.CompareTo(other.Value);
        }


        //depricated, will be removed soon
        public static void sortAndPrintChartFive(string[,] tableToSort)
        {

            List<TopScoresChartEntry> scoreBoard = new List<TopScoresChartEntry>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                scoreBoard.Add(new TopScoresChartEntry(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }

            scoreBoard.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < scoreBoard.Count; ++i)
            {
                TopScoresChartEntry slot = scoreBoard[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");


        }
        public override string ToString()
        {
            return String.Format("{0} with {1} moves.", this.Name, this.Value);
        }
    }
}
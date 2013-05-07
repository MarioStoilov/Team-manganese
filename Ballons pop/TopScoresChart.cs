using System;
using System.Collections.Generic;

namespace BalloonsPop
{
    public class TopScoresChart : IComparable<TopScoresChart>
    {
        public int Value;
        public string Name;

        public TopScoresChart(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int CompareTo(TopScoresChart other)
        {
            return Value.CompareTo(other.Value);
        }

        // 
        public static void sortAndPrintChartFive(string[,] tableToSort)
        {

            List<TopScoresChart> klasirane = new List<TopScoresChart>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new TopScoresChart(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }

            klasirane.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < klasirane.Count; ++i)
            {
                TopScoresChart slot = klasirane[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");


        }
    }
}
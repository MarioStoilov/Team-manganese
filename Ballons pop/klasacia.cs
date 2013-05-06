using System;
using System.Collections.Generic;

namespace BalloonsPop
{
    public class klasacia : IComparable<klasacia>
    {
        public int Value;
        public string Name;

        public klasacia(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int CompareTo(klasacia other)
        {
            return Value.CompareTo(other.Value);
        }

        // 
        public static void sortAndPrintChartFive(string[,] tableToSort)
        {

            List<klasacia> klasirane = new List<klasacia>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new klasacia(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }

            klasirane.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < klasirane.Count; ++i)
            {
                klasacia slot = klasirane[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");


        }
    }
}
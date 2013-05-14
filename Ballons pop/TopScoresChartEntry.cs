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

        public override string ToString()
        {
            return String.Format("{0} with {1} moves.", this.Name, this.Value);
        }
    }
}
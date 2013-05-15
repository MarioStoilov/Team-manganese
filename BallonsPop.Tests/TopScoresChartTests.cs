using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPop;

namespace BallonsPop.Tests
{
    [TestClass]
    public class TopScoresChartTests
    {
        [TestMethod]
        public void CheckIfHighScoreIsAchievedTest()
        {
            TopScoresChart topscores = new TopScoresChart(5);
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            Assert.IsTrue(topscores.CheckIfHighScoreIsAchieved(player.Score));
        }

        [TestMethod]
        public void AddEntryTest()
        {
            TopScoresChart topscores = new TopScoresChart(5);
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            Assert.IsTrue(topscores != null);
        }

        [TestMethod]
        public void ToStringTest()
        {
            TopScoresChart topscores = new TopScoresChart(5);
            int score = 123;
            string name = "Kaloyan";
            TopScoresChartEntry player = new TopScoresChartEntry(score, name);
            topscores.AddScore(player);
            string toStringExpectedReturn = "1. Kaloyan with 123 moves.\r\n2. \r\n3. \r\n4. \r\n5. \r\n";
            string returnString = topscores.ToString();
            Assert.AreEqual(toStringExpectedReturn, returnString);
        }
    }
}

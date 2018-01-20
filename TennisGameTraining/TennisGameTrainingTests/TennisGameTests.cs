using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGameTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGameTraining.Tests
{
    [TestClass()]
    public class TennisGameTests
    {
        [TestMethod()]
        public void Love_All()
        {
            TennisGame tennisGame = new TennisGame();
            var excepct = "Love_All";
            var actual = tennisGame.GetCurrentScore();

            Assert.AreEqual(excepct, actual);
        }

        [TestMethod]
        public void Fiften_Love()
        {
            TennisPlayer homePlayer = new TennisPlayer()
                                          {
                                              TennisPlayerType = TennisPlayerType.HomePlayer,
                                              TennisCurrentScore = TennisScore.Love
                                          };
            TennisPlayer awayPlayer = new TennisPlayer()
                                        {
                                            TennisPlayerType = TennisPlayerType.AwayPlayer,
                                            TennisCurrentScore = TennisScore.Love
                                        };

            TennisGame tennisGame = new TennisGame(homePlayer, awayPlayer);
            var excepct = "Fiften_Love";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }
    }
}
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
        public TennisPlayer HomePlayer{ get; set; }
        public TennisPlayer AwayPlayer { get; set; }

        private void InitialPlayer(TennisScore homeCurrentScore, TennisScore awayTennisScore)
        {
            this.HomePlayer = new TennisPlayer()
                                          {
                                              TennisPlayerType = TennisPlayerType.HomePlayer,
                                              TennisCurrentScore = homeCurrentScore
            };
            this.AwayPlayer= new TennisPlayer()
                                          {
                                              TennisPlayerType = TennisPlayerType.AwayPlayer,
                                              TennisCurrentScore = awayTennisScore
            };
        }

        [TestMethod()]
        public void Love_Love_None_Love_ALL()
        {
            this.InitialPlayer(TennisScore.Love, TennisScore.Love);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Love_All";
            var actual = tennisGame.GetCurrentScore();

            Assert.AreEqual(excepct, actual);
        }

        #region Love vs. Love
        [TestMethod]
        public void Love_Love_Home_Fiften_Love()
        {
            this.InitialPlayer(TennisScore.Love, TennisScore.Love);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);

            var excepct = "Fiften_Love";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }

        [TestMethod()]
        public void Love_Love_Away_Love_Fifty()
        {
            this.InitialPlayer(TennisScore.Love, TennisScore.Love);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Love_Fiften";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.AwayPlayer);

            Assert.AreEqual(excepct, actual);
        }
        #endregion

        #region Fiften V.S. Love
        [TestMethod]
        public void Fiften_Love_Home_Thirty_Love()
        {
            this.InitialPlayer(TennisScore.Fiften, TennisScore.Love);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Thirty_Love";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }

        [TestMethod]
        public void Fiften_Love_Away_Fiften_Fiften()
        {
            this.InitialPlayer(TennisScore.Fiften, TennisScore.Love);

            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Fiften_Fiften";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.AwayPlayer);

            Assert.AreEqual(excepct, actual);
        }
        #endregion

        #region Fiften V.S. Fiften
        [TestMethod]
        public void Fiften_Fiften_Home_Thirty_Fiften()
        {
            this.InitialPlayer(TennisScore.Fiften, TennisScore.Fiften);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Thirty_Fiften";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }
        [TestMethod]
        public void Fiften_Fiften_Away_Fiften_Thirty()
        {
            this.InitialPlayer(TennisScore.Fiften, TennisScore.Fiften);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Fiften_Thirty";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.AwayPlayer);

            Assert.AreEqual(excepct, actual);
        }
        #endregion

        #region Fiften V.S. Thirty
        [TestMethod]
        public void Fiften_Thirty_Home_Thirty_Thirty()
        {
            this.InitialPlayer(TennisScore.Fiften, TennisScore.Thirty);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Thirty_Thirty";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }
        [TestMethod]
        public void Fiften_Thirty_Away_Away_Win()
        {
            this.InitialPlayer(TennisScore.Fiften, TennisScore.Thirty);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Away_Win";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.AwayPlayer);

            Assert.AreEqual(excepct, actual);
        }
        #endregion

        #region Thirty V.S. Love
        [TestMethod]
        public void Thirty_Love_Home_Home_Win()
        {
            this.InitialPlayer(TennisScore.Thirty, TennisScore.Love);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Home_Win";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }
        [TestMethod]
        public void Thirty_Love_Away_Thirty_Fiften()
        {
            this.InitialPlayer(TennisScore.Thirty, TennisScore.Love);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Thirty_Fiften";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.AwayPlayer);

            Assert.AreEqual(excepct, actual);
        }
        #endregion

        #region Thirty V.S. Fiften
        [TestMethod]
        public void Thirty_Fiften_Home_Home_Win()
        {
            this.InitialPlayer(TennisScore.Thirty, TennisScore.Fiften);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Home_Win";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.HomePlayer);

            Assert.AreEqual(excepct, actual);
        }
        [TestMethod]
        public void Thirty_Fiften_Away_Thirty_Thirty()
        {
            this.InitialPlayer(TennisScore.Thirty, TennisScore.Fiften);
            TennisGame tennisGame = new TennisGame(this.HomePlayer, this.AwayPlayer);
            var excepct = "Thirty_Thirty";
            var actual = tennisGame.GetCurrentScore(TennisPlayerType.AwayPlayer);

            Assert.AreEqual(excepct, actual);
        }
        #endregion


    }
}
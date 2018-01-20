using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGameTraining
{
    public class TennisGame
    {
        public TennisPlayer HomePlayer { get; set; }
        public TennisPlayer AwayPlayer { get; set; }

        public TennisGame()
        {
            this.HomePlayer = new TennisPlayer()
                                  {
                                      TennisPlayerType = TennisPlayerType.HomePlayer,
                                      TennisCurrentScore = TennisScore.Love
                                  };
            this.AwayPlayer = new TennisPlayer()
                                  {
                                      TennisPlayerType = TennisPlayerType.AwayPlayer,
                                      TennisCurrentScore = TennisScore.Love
                                  };
        }

        public TennisGame(TennisPlayer homePlayer, TennisPlayer awayPlayer)
        {
            this.HomePlayer = homePlayer;
            this.AwayPlayer = awayPlayer;
        }

        public string GetCurrentScore(TennisPlayerType winnerPlayerType = TennisPlayerType.None)
        {
            this.HomePlayer.TennisCurrentScore = this.PlayerScore(this.HomePlayer, winnerPlayerType);
            this.AwayPlayer.TennisCurrentScore = this.PlayerScore(this.AwayPlayer, winnerPlayerType);

            return this.ScoreDisplay();
        }

        private TennisScore PlayerScore(TennisPlayer tennisPlayer, TennisPlayerType winnerPlayerType)
        {
            if (tennisPlayer.TennisPlayerType == winnerPlayerType)
            {
                if (tennisPlayer.TennisCurrentScore == TennisScore.Love)
                {
                    return TennisScore.Fiften;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Fiften)
                {
                    return TennisScore.Thirty;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Thirty)
                {
                    return TennisScore.Forty;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Forty)
                {
                    return TennisScore.Adv;
                }
            }

            return tennisPlayer.TennisCurrentScore;
        }

        private string ScoreDisplay()
        {
            if (this.HomePlayer.TennisCurrentScore == TennisScore.Forty &&
                     this.AwayPlayer.TennisCurrentScore == TennisScore.Forty)
            {
                return $"Deuce";
            }
            else if (this.HomePlayer.TennisCurrentScore<TennisScore.Forty&&
                     this.AwayPlayer.TennisCurrentScore<TennisScore.Forty&&
                     this.HomePlayer.TennisCurrentScore == this.AwayPlayer.TennisCurrentScore )
            {
                return $"{this.HomePlayer.TennisCurrentScore}_All";
            }
            else if (this.HomePlayer.TennisCurrentScore >= TennisScore.Forty&&
                     (this.HomePlayer.TennisCurrentScore-this.AwayPlayer.TennisCurrentScore>=2))
            {
                return $"Home_Win";
            }
            else if (this.AwayPlayer.TennisCurrentScore >= TennisScore.Forty&&
                    (this.AwayPlayer.TennisCurrentScore-this.HomePlayer.TennisCurrentScore>=2))
            {
                return $"Away_Win";
            }
            else
            {
                return $"{this.HomePlayer.TennisCurrentScore.ToString()}_{this.AwayPlayer.TennisCurrentScore.ToString()}";
            }
        }


    }
}

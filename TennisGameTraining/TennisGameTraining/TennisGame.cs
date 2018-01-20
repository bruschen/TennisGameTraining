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
            TennisScore homeTennisScore= this.PlayerScore(this.HomePlayer, this.AwayPlayer.TennisCurrentScore, winnerPlayerType);
            TennisScore awayTennisScore= this.PlayerScore(this.AwayPlayer, this.HomePlayer.TennisCurrentScore, winnerPlayerType);

            return this.ScoreDisplay(homeTennisScore, awayTennisScore);
        }

        private TennisScore PlayerScore(TennisPlayer tennisPlayer, TennisScore opponentScore, TennisPlayerType winnerPlayerType)
        {
            TennisScore playerCurrentScore = tennisPlayer.TennisCurrentScore;

            if (tennisPlayer.TennisPlayerType == winnerPlayerType)
            {
                if (tennisPlayer.TennisCurrentScore == TennisScore.Love)
                {
                    playerCurrentScore= TennisScore.Fiften;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Fiften)
                {
                    playerCurrentScore = TennisScore.Thirty;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Thirty)
                {
                    playerCurrentScore = TennisScore.Forty;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Forty &&
                         opponentScore==TennisScore.Adv)
                {   //Adv_Adv ==> deuce
                    playerCurrentScore = TennisScore.Forty;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Forty)
                {
                    playerCurrentScore = TennisScore.Adv;
                }
                else if (tennisPlayer.TennisCurrentScore == TennisScore.Adv)
                {
                    playerCurrentScore = TennisScore.Win;
                }
            }
            else
            {
                if (tennisPlayer.TennisCurrentScore == TennisScore.Adv &&
                         opponentScore == TennisScore.Forty)
                {   //Adv_Adv ==> deuce
                    playerCurrentScore = TennisScore.Forty;
                }
            }
            return playerCurrentScore;
        }

        private string ScoreDisplay(TennisScore homeTennisScore, TennisScore awayTennisScore)
        {
            if (homeTennisScore == TennisScore.Forty &&
                awayTennisScore == TennisScore.Forty)
            {
                return $"Deuce";
            }
            else if (homeTennisScore < TennisScore.Forty&&
                     awayTennisScore < TennisScore.Forty&&
                     homeTennisScore == awayTennisScore)
            {
                return $"{awayTennisScore}_All";
            }
            else if (homeTennisScore >= TennisScore.Forty&&
                     (homeTennisScore - awayTennisScore >= 2))
            {
                return $"Home_Win";
            }
            else if (awayTennisScore >= TennisScore.Forty&&
                    (awayTennisScore - homeTennisScore >= 2))
            {
                return $"Away_Win";
            }
            else
            {
                return $"{homeTennisScore.ToString()}_{awayTennisScore.ToString()}";
            }
        }


    }
}

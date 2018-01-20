using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGameTraining
{
    using System.Security.AccessControl;

    public class TennisPlayer
    {
        public TennisPlayerType TennisPlayerType { get; set; }

        public TennisScore TennisCurrentScore { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGameTraining
{
    using System.ComponentModel;

    public enum TennisScore
    {
        [Description("Love")]
        Love=0,
        [Description("Fiften")]
        Fiften=1,
        [Description("Thirty")]
        Thirty=2,
        [Description("Forty")]
        Forty=3,
        [Description("Adv")]
        Adv=4,
        [Description("Win")]
        Win = 5,
    }
}

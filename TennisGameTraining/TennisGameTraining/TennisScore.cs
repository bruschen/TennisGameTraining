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
        Love,
        [Description("Fiften")]
        Fiften,
        [Description("Thirty")]
        Thirty,
        [Description("Forty")]
        Forty,
        [Description("Advantage")]
        Advantage,
    }
}

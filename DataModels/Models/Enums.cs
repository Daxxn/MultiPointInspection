using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Enums
{
    public enum Colors
    {
        Red,
        White,
        Black,
        Blue,
        Brown,
        Orange,
        Gray,
        Tan
    }

    public enum Result
    {
        Good = 5,
        Fair = 4,
        Normal = 3,
        Poor = 2,
        Bad = 1,
        NA = 0,
        Open = 10
    }

    public enum Status
    {
        Open,
        Started,
        InProgress,
        Completed
    }
}

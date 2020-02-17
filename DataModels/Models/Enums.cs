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

    public enum InspectionCategory
    {
        Lighting = 1,
        Interior = 2,
        UnderHoodFluids = 3,
        UnderHoodComponents = 4,
        Tires = 5,
        Brakes = 6,
        DrivetrainFluids = 7,
        UnderVehicle = 8,
        FluidLeaks = 9,
        Time_Mileage = 10,

        NA = 0
    }
}

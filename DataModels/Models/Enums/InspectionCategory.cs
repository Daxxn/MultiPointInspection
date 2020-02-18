using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Enums
{
    public enum InspectionCategory
    {
        [Display(Description = "Lighing")]
        Lighting = 1,

        [Display(Description = "Interior")]
        Interior = 2,

        [Display(Description = "Under Hood Fluids")]
        UnderHoodFluids = 3,

        [Display(Description = "Under Hood Components")]
        UnderHoodComponents = 4,

        [Display(Description = "Tires")]
        Tires = 5,

        [Display(Description = "Brakes")]
        Brakes = 6,

        [Display(Description = "Drivetrain Fluids")]
        DrivetrainFluids = 7,

        [Display(Description = "Under Vehicle")]
        UnderVehicle = 8,

        [Display(Description = "Fluid Leaks")]
        FluidLeaks = 9,

        [Display(Description = "Time / Mileage")]
        Time_Mileage = 10,

        [Display(Description = "N/A")]
        NA = 0
    }
}

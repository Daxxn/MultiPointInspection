using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Enums
{
    public enum Result
    {
        [Display(Description = "Good")]
        Good = 5,

        [Display(Description = "Fair")]
        Fair = 4,

        [Display(Description = "Normal")]
        Normal = 3,

        [Display(Description = "Poor")]
        Poor = 2,

        [Display(Description = "Bad")]
        Bad = 1,

        [Display(Description = "N/A")]
        NA = 0,

        [Display(Description = "Open")]
        Open = 10
    }
}

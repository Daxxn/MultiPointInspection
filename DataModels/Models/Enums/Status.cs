using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Enums
{
    public enum Status
    {
        [Display(Description = "Open")]
        Open,

        [Display(Description = "Started")]
        Started,

        [Display(Description = "In Progress")]
        InProgress,

        [Display(Description = "Completed")]
        Completed
    }
}

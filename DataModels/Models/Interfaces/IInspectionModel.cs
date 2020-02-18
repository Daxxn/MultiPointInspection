using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Interfaces
{
    public interface IInspectionModel : IJson
    {
        string Name { get; set; }
        List<Inspect> InspectionData { get; set; }
    }
}

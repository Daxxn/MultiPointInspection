using DataModels.Models.Enums;

namespace DataModels.Models.Interfaces
{
    public interface IInspectModel : IJson
    {
        InspectionCategory Category { get; set; }
        string Description { get; set; }
        int? Measurement { get; set; }
        Result Result { get; set; }
        string Specs { get; set; }
        string Title { get; set; }
    }
}
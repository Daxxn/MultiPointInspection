using System;
using System.Collections.Generic;
using DataModels.Models;
using DataModels.Models.Interfaces;

namespace DataModels.Models
{
    public class Inspection : IInspectionModel
    {
        #region - Fields
        public string Name { get; set; }
        public List<Inspect> InspectionData { get; set; } = new List<Inspect>();
        #endregion

        #region - Constructors

        #endregion

        #region - Methods

        #endregion

        #region - Properties

        #endregion
    }
}

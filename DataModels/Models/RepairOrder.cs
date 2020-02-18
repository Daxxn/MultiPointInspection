using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class RepairOrder
    {
        #region - Fields
        public int RepairOrderNumber { get; set; }
        public VehicleData Vehicle { get; set; }
        public List<RepairAction> Repairs { get; set; }
        public Inspection Inspection { get; set; }
        public RepairStatus Status { get; set; }
        #endregion

        #region - Constructors
        #endregion

        #region - Methods

        #endregion

        #region - Properties

        #endregion
    }
}

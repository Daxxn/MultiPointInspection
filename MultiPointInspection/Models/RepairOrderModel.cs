using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataModels.Enums;

namespace MultiPointInspection.Models
{
    public class RepairOrderModel
    {
        #region - Fields
        public List<RepairOrder> ActiveRepairOrders { get; set; }

        #endregion

        #region - Constructors
        public RepairOrderModel()
        {
            #region TESTING
            ActiveRepairOrders.Add(new RepairOrder()
            {
                RepairOrderNumber = 123456,
                Vehicle = new VehicleData()
                {
                    VIN = "VIN Test",
                    Year = 2018,
                    Make = "Toyota",
                    Model = "RAV4"
                },
                Inspection = new Inspection()
                {
                    Components = new List<Component>()
                    {
                        new Component("Brakes"),
                        new Component("Tread Depth"),
                        new Component("Engine Filter")
                    },

                },
                Status = new RepairStatus()
                {
                    Name = "In Progress",
                    ID = 1
                },
                Repairs = new List<RepairAction>()
                {
                    new RepairAction()
                    {
                        RepairName = "Oil change and tire rotate.",
                        ActionID = 10,
                        Description = "Replace engine oil and filter, rotate tires, check tire pressure, and complete multipoint inspection."
                    }
                }
            });
            #endregion
        }
        #endregion

        #region - Methods

        #endregion

        #region - Properties

        #endregion
    }
}

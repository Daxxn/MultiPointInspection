using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    /// <summary>
    /// Need to change. Need to turn into a class or something.
    /// </summary>
    public struct RepairStatus
    {
        public static List<RepairStatus> AllRepairStatusses = new List<RepairStatus>();

        public string Name;
        public int ID;

        public static RepairStatus New(string name, int id)
        {
            return new RepairStatus()
            {
                Name = name,
                ID = id
            };
        }
    }
}

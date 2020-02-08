using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public struct RepairStatus
    {
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

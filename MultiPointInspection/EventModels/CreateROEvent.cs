using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPointInspection.EventModels
{
    public class CreateROEvent
    {
        public RepairOrder RO { get; set; }

        public CreateROEvent( RepairOrder ro )
        {
            RO = ro;
        }
    }
}

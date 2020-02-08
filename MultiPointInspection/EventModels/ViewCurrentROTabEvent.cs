using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPointInspection.EventModels
{
    public class ViewCurrentROTabEvent
	{
		#region - Fields & Properties
		public RepairOrder RO { get; private set; }
		#endregion

		#region - Constructors
		public ViewCurrentROTabEvent(RepairOrder ro)
		{
			RO = ro;
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}

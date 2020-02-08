using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataModels;

namespace MultiPointInspection.EventModels
{
    public class ViewInspectionTabEvent
	{
		#region - Fields & Properties
		public RepairOrder SelectedRO { get; private set; }
		#endregion

		#region - Constructors
		public ViewInspectionTabEvent(RepairOrder ro)
		{
			SelectedRO = ro;
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}

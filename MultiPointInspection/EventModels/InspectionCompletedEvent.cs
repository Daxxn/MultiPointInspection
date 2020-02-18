using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPointInspection.EventModels
{
    public class InspectionCompletedEvent
	{
		#region - Fields & Properties
		public Inspection Inspection { get; set; }
		#endregion

		#region - Constructors
		public InspectionCompletedEvent( Inspection inspection )
		{
			Inspection = inspection;
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}

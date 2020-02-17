using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Inspect
	{
		#region - Fields & Properties
		public string Title { get; set; }
		public InspectionCategory Category { get; set; }
		public string Description { get; set; }
		public Result Result { get; set; }
		public int Measurement { get; set; }
		public string Specs { get; set; }
		#endregion

		#region - Constructors
		public Inspect( ) { }
		public Inspect( string title )
		{
			Title = title;
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}

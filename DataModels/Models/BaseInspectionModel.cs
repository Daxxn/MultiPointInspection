using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DataModels.Models
{
    public class BaseInspectionModel
	{
		#region - Fields & Properties
		public List<Component> Components { get; set; }
		#endregion

		#region - Constructors
		public BaseInspectionModel()
		{
			Components = new List<Component>()
			{
				new Component("Interior Light Bulbs"),
                new Component("Interior Light Operation"),
                new Component("Exterior Light Bulbs"),
                new Component("Exterior Light Operation"),

                new Component("Tread Depth Left Front"),
                new Component("Tread Depth Right Front"),
                new Component("Tread Depth Left Rear"),
                new Component("Tread Depth Right Rear"),
				new Component("Overall Tire Condition"),

                new Component("Front Brake Pad Thickness"),
                new Component("Rear Brake Pad Thickness"),
				new Component("Overall Brake Condition"),

				new Component("Front Diff. Oil Condition"),
				new Component("Rear Diff. Oil Condition"),
                new Component("Transfer Case Oil Condition"),

                new Component("Engine Oil Leaks"),
				new Component("Transmission Oil Leaks"),
				new Component("Power Steering Fluid Leaks"),
				new Component("Brake Fluid Leaks"),
				new Component("Differential Oil Leaks")
            };
		}
		#endregion

		#region - Methods

		#endregion

		#region - Full Properties

		#endregion
	}
}

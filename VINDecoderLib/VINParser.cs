using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINParser
	{
		#region - Fields & Properties
		/// <summary>
		/// OLD
		/// </summary>
		public VINModel VINData { get; set; }
		/// <summary>
		/// OLD
		/// </summary>
		public List<int> Matches { get; set; } = new List<int>()
			{
				191, 26, 27, 28, 29, 31, 34, 38, 39, 75, 77, 5, 14,
				25, 54, 37, 63, 15, 9, 11, 12, 13, 18, 21, 62, 64, 168
			};
		/// <summary>
		/// OLD
		/// </summary>
		public Dictionary<string,string> AllData { get; set; }
		#endregion

		#region - Constructors
		public VINParser( ) { }
		#endregion

		#region - Methods
		/// <summary>
		/// Parses the VIN Model data into a Vehicle Model
		/// </summary>
		/// <typeparam name="T">ONLY VehicleModel, just trying to get around a bug. need to fix later.</typeparam>
		/// <param name="vinData">VINResultModel from the list of results</param>
		/// <returns>Returns a complete VehicleModel with parsed numbers.</returns>
		public static T ParseVINModel<T>( VINResultModel vinData ) where T : new()
		{
			T output = new T();

			var vehicleProps = output.GetType().GetProperties();
			var vinProps = vinData.GetType().GetProperties();

			foreach (var vinProp in vinProps)
			{
				foreach (var vehicleProp in vehicleProps)
				{
					if (vinProp.Name == vehicleProp.Name)
					{
						if (vehicleProp.PropertyType == typeof(String))
						{
							output.GetType().GetProperty(vehicleProp.Name).SetValue(output, vinProp.GetValue(vinData));
						}
						else if (vehicleProp.PropertyType == typeof(Int32))
						{
							bool success = Int32.TryParse((string)vinProp.GetValue(vinData), out int intOut);

							if (success)
							{
								vehicleProp.SetValue(output, intOut);
							}
						}
						else if (vehicleProp.PropertyType == typeof(Double))
						{
							bool success = Double.TryParse((string)vinProp.GetValue(vinData), out double doubleOut);

							if (success)
							{
								vehicleProp.SetValue(output, doubleOut);
							}
						}
						else if (vehicleProp.PropertyType == typeof(Int32[]))
						{
							vehicleProp.SetValue(output, ParseErrorCode((string)vinProp.GetValue(vinData)));
						}
						break;
					}
				}
			}

			return output;
		}

		public static int[] ParseErrorCode( string input )
		{
			if (input.Length > 1)
			{
				List<int> output = new List<int>();
				string[] splitOut = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var num in splitOut)
				{
					bool success = Int32.TryParse(num, out int parseOut);
					output.Add(parseOut);
				}
				return output.ToArray();
			}
			else
			{
				Int32.TryParse(input[ 0 ].ToString(), out int parseOut);
				return new int[] { parseOut };
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

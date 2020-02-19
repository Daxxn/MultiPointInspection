using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class VehicleData
	{
		#region - Fields & Properties
		public string VIN { get; set; }
		public string ErrorText { get; set; }
		public string Make { get; set; }
		public string ManufacturerName { get; set; }
		public string Model { get; set; }
		public int ModelYear { get; set; }
		public string PlantCity { get; set; }
		public string Series { get; set; }
		public string Trim { get; set; }
		public string VehicleType { get; set; }
		public string PlantCountry { get; set; }
		public string PlantState { get; set; }
		public string BodyClass { get; set; }
		public int Doors { get; set; }
		public string GrossVehicleWeightRating { get; set; }
		public int CurbWeightpounds { get; set; }
		public string TransmissionStyle { get; set; }
		public int TransmissionSpeeds { get; set; }
		public string DriveType { get; set; }
		public int EngineNumberofCylinders { get; set; }
		public double DisplacementCC { get; set; }
		public double DisplacementCI { get; set; }
		public double DisplacementL { get; set; }
		public string EngineModel { get; set; }
		public double EnginePowerKW { get; set; }
		public string FuelType { get; set; }
		public string ValveTrainDesign { get; set; }
		public string EngineConfiguration { get; set; }
		public string TPMS { get; set; }
		// Not specified in VIN.
		public string Color { get; set; }

		public Dictionary<string, string> RawData { get; set; }
		#endregion

		#region - Constructors
		public VehicleData( ) { }
		#endregion

		#region - Methods
		public void ConvertRawData( )
		{
			var properties = this.GetType().GetProperties();

			foreach (var key in RawData.Keys)
			{

				foreach (var pr in properties)
				{
					if (key == pr.Name)
					{
						if (pr.PropertyType == typeof(Int32))
						{
							Int32.TryParse(RawData[ key ], out int parseOut);
							pr.SetValue(this, parseOut);
						}
						else if (pr.PropertyType == typeof(double))
						{
							Double.TryParse(RawData[ key ], out double parseOut);
							pr.SetValue(this, parseOut);
						}
						else
						{
							pr.SetValue(this, RawData[ key ]);
						}
						break;
					}
				}
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

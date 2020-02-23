using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VINDecoderLib;

namespace DataModels
{
    public class VehicleData
	{
		#region - Fields & Properties
		public int[] ErrorCode { get; set; }
		public string VIN { get; set; }
		public string BodyClass { get; set; }
		public string BedType { get; set; }
		public int CurbWeightLB { get; set; }
		public double DisplacementCI { get; set; }
		public double DisplacementL { get; set; }
		public int Doors { get; set; }
		public string DriveType { get; set; }
		public string EngineConfiguration { get; set; }
		public int EngineCylinders { get; set; }
		public double EngineHP { get; set; }
		public double EngineKW { get; set; }
		public string EngineModel { get; set; }
		public string Make { get; set; }
		public int ManufacturerId { get; set; }
		public string Model { get; set; }
		public int ModelYear { get; set; }
		public string PlantCountry { get; set; }
		public string Series { get; set; }
		public string Trim { get; set; }
		public string TPMS { get; set; }
		public int TransmissionSpeeds { get; set; }
		public string TransmissionStyle { get; set; }
		public string ValveTrainDesign { get; set; }
		public string VehicleType { get; set; }
		public string FuelTypePrimary { get; set; }
		public string FuelInjectionType { get; set; }
		public string Color { get; set; }

		//public VehicleCache Cache { get; set; } = new VehicleCache();
		#endregion

		#region - Constructors
		public VehicleData( ) { }
		#endregion

		#region - Methods
		public override string ToString( )
		{
			string output = "";
			var props = this.GetType().GetProperties();

			foreach (var prop in props)
			{
				output += $"{prop.GetValue(this)} , ";
			}

			return output;
		}

		public static async Task<VehicleData> RequestVINAsync( string vin )
		{
			if (!VehicleCache.CheckCache(vin))
			{
				VINModel vinData = await VINController.GetVinFlatAsync(vin);
				VehicleData output = VINParser.ParseVINModel<VehicleData>(vinData.Results[ 0 ]);
				VehicleCache.Add(output);
				return output;
			}
			else
			{
				return VehicleCache.Get(vin);
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

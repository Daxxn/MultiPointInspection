using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINResultModel
    {
		#region - Fields & Properties
		public string ErrorCode { get; set; }
		public string VIN { get; set; }
		public string BodyClass { get; set; }
		public string BedType { get; set; }
		public string CurbWeightLB { get; set; }
		public string DisplacementCI { get; set; }
		public string DisplacementL { get; set; }
		public string Doors { get; set; }
		public string DriveType { get; set; }
		public string EngineConfiguration { get; set; }
		public string EngineCylinders { get; set; }
		public string EngineHP { get; set; }
		public string EngineKW { get; set; }
		public string EngineModel { get; set; }
		public string Make { get; set; }
		public string ManufacturerId { get; set; }
		public string Model { get; set; }
		public string ModelYear { get; set; }
		public string PlantCountry { get; set; }
		public string Series { get; set; }
		public string Trim { get; set; }
		public string TPMS { get; set; }
		public string TransmissionSpeeds { get; set; }
		public string TransmissionStyle { get; set; }
		public string ValveTrainDesign { get; set; }
		public string VehicleType { get; set; }
		public string FuelTypePrimary { get; set; }
		public string FuelInjectionType { get; set; }
		#endregion

		#region - Constructors
		public VINResultModel( ) { }
		#endregion

		#region - Methods
		public override string ToString( )
		{
			StringBuilder sb = new StringBuilder("VIN Result: ");
			var props = this.GetType().GetProperties();

			foreach (var prop in props)
			{
				sb.AppendLine($"{prop.Name} : {prop.GetValue(this)}");
			}

			return sb.ToString();
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

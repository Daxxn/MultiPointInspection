using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINJsonModel
	{
		#region - Fields & Properties
		public int Count { get; set; }
		public string Message { get; set; }
		public string SearchCriteria { get; set; }
		public List<VINJsonResultModel> Results { get; set; }
		#endregion

		#region - Constructors
		public VINJsonModel( ) { }
		#endregion

		#region - Methods
		public override string ToString( )
		{
			StringBuilder bd = new StringBuilder();

			bd.AppendLine($"Results Count: {Count}");
			bd.AppendLine($"Message: {Message}");
			bd.AppendLine($"VIN: {SearchCriteria}");

			foreach (var result in Results)
			{
				bd.AppendLine(result.ToString());
			}

			return bd.ToString();
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

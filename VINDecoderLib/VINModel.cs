using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINModel
	{
		#region - Fields & Properties
		public string Message { get; set; }
		public string SearchCriteria { get; set; }
		public List<VINResultModel> Results { get; set; }
		#endregion

		#region - Constructors
		public VINModel( ) { }
		#endregion

		#region - Methods
		public override string ToString( )
		{
			StringBuilder sb = new StringBuilder("VIN Model :");
			sb.AppendLine(Message);
			sb.AppendLine(SearchCriteria);

			foreach (var result in Results)
			{
				sb.AppendLine(result.ToString());
			}

			return sb.ToString();
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

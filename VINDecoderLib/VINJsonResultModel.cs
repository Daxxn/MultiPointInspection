using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINJsonResultModel
	{
		#region - Fields & Properties
		public string Value { get; set; }
		public string ValueId { get; set; }
		public string Variable { get; set; }
		public int VariableId { get; set; }
		#endregion

		#region - Constructors
		public VINJsonResultModel( ) { }
		#endregion

		#region Methods
		public override string ToString( )
		{
			return $"{Variable} : {Value}";
		}
		#endregion
	}
}

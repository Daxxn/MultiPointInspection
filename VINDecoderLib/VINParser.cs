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
		public VINJsonModel VINData { get; set; }
		public List<int> Matches { get; set; } = new List<int>()
			{
				191, 26, 27, 28, 29, 31, 34, 38, 39, 75, 77, 5, 14,
				25, 54, 37, 63, 15, 9, 11, 12, 13, 18, 21, 62, 64, 168
			};
		public Dictionary<string,string> AllData { get; set; }
		#endregion

		#region - Constructors
		public VINParser( ) { }
		#endregion

		#region - Methods
		public Dictionary<string,string> ParseVINResults( )
		{
			Dictionary<string,string> output = new Dictionary<string, string>();
			foreach (var result in VINData.Results)
			{
				if (Matches.Contains(result.VariableID))
				{
					output.Add(NameCleaner(result.Variable), result.Value);
				}
			}

			return output;
		}

		private string NameCleaner( string input )
		{
			string output = "";
			for (int i = 0; i < input.Length; i++)
			{
				if (Char.IsLetter(input[ i ]))
				{
					output += input[ i ];
				}
			}

			return output;
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

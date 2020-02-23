using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINCache
	{
		#region - Fields & Properties
		public List<VINJsonModel> Cache { get; set; }
		#endregion

		#region - Constructors
		public VINCache( ) { }
		#endregion

		#region - Methods
		public void AddVinResult( VINJsonModel newVin )
		{
			if (Cache.Contains(newVin))
			{
				Cache.Add(newVin);
			}
		}

		public bool CheckCache( string input )
		{
			return Cache.Any(x => x.SearchCriteria == input);
		}

		public VINJsonModel GetVINFromCache( string vin )
		{
			return Cache.Find(x => x.SearchCriteria == vin);
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

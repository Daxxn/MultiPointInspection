using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
	/// <summary>
	/// Basic Vehicle Caching class
	/// </summary>
    public static class VehicleCache
	{
		#region - Fields & Properties
		/// <summary>
		/// The cached vehicles. Maybe change to caching VINs only??
		/// </summary>
		public static List<VehicleData> Cache { get; set; } = new List<VehicleData>();
		#endregion

		#region - Constructors
		#endregion

		#region - Methods
		public static void Add( VehicleData inputVehicle )
		{
			if (!Cache.Contains(inputVehicle))
			{
				Cache.Add(inputVehicle);
			}
		}

		/// <summary>
		/// Gets the vehicle and its data if the input VIN matches a vehicle.
		/// </summary>
		/// <param name="vin">VIN to search for</param>
		/// <returns>The vehicle data</returns>
		public static VehicleData Get( string vin )
		{
			if (CheckCache(vin))
			{
				return Cache.Find(vehicle => vehicle.VIN == vin);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Checks the cache for a particular VIN.
		/// </summary>
		/// <param name="vin">The VIN to look for.</param>
		/// <returns>Returns true if a vehicle is found.</returns>
		public static bool CheckCache( string vin )
		{
			return Cache.Any(x => x.VIN == vin);
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}

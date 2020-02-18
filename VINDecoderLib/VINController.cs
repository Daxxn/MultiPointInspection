using APIControlLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VINDecoderLib
{
    public class VINController
    {
        #region Test VINs
        public static string JasonsVIN { get; } = "JHMGE8H52DC071704";
        public static string DadsVIN { get; set; } = "KMHD84LF3HU153568";
        #endregion

        public static string VinApiUrl { get; } = @"https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/";
        public static string VINDecodeOneFormatJson { get; } = "?format=json";
        public static async Task<VINJsonModel> LoadVIN( string vin )
        {
            string fullUrl = "";
            if (!string.IsNullOrEmpty(vin))
            {
                fullUrl = $"{VinApiUrl}{vin}{VINDecodeOneFormatJson}";
            }
            else
            {
                throw new Exception("Vin is null or empty.");
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(fullUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    return JsonControlLib.JsonController.ConvertStringToObject<VINJsonModel>(await response.Content.ReadAsStringAsync());
                    //return JsonConvert.DeserializeObject<VINJsonModel>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

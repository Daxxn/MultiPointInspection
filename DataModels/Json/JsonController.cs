using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Json
{
    public static class JsonController
	{
        #region - Fields & Properties

        #endregion

        #region - Methods
        public static string ConvertObjectToString<T>( T convertObject )
        {
            try
            {
                return JsonConvert.SerializeObject(convertObject, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ConvertStringToObject<T>( string input )
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}

using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataModels
{
    public class Inspection : BaseInspectionModel
    {
        #region - Fields
        public VehicleData Vehicle { get; set; }

        //public List<Component> Components { get; set; }
        #endregion

        #region - Constructors

        #endregion

        #region - Methods
        public void ReadJson(string path)
        {
            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    ObjectCreationHandling.
            //}
            JsonSerializer serializer = JsonSerializer.Create();
            serializer.
        }

        public void WriteJson(string path)
        {
            JsonConvert.SerializeObject(Components);
        }
        #endregion

        #region - Properties

        #endregion
    }
}

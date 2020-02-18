using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models.Enums;

namespace DataModels
{
    public class Component
    {
        #region - Fields
        public string Name { get; set; } = "";
        public Result Result { get; set; } = Result.Open;
        public string Note { get; set; } = "";
        #endregion

        #region - Constructors
        public Component() { }
        public Component(string name)
        {
            Name = name;
        }

        public Component(string name, Result result)
        {
            Name = name;
            Result = result;
        }
        #endregion

        #region - Methods

        #endregion

        #region - Properties

        #endregion
    }
}

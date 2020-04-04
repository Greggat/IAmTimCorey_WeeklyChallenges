using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    class UserModelBuilder
    {
        private UserModel _userModel;

        public UserModelBuilder()
        {
            _userModel = new UserModel();
        }

        public UserModelBuilder AddProperty(string propertyName, string propertyValue)
        {
            switch (propertyName)
            {
                case "FirstName":
                    _userModel.FirstName = propertyValue;
                    break;
                case "LastName":
                    _userModel.LastName = propertyValue;
                    break;
                case "Age":
                    _userModel.Age = Convert.ToInt32(propertyValue);
                    break;
                case "IsAlive":
                    _userModel.IsAlive = (propertyValue == "1");
                    break;
                default:
                    throw new Exception($"Failed to parse file. Invalid Property Name: {propertyName}.");
            }

            return this;
        }

        public UserModel Build()
        {
            return _userModel;
        }
    }
}

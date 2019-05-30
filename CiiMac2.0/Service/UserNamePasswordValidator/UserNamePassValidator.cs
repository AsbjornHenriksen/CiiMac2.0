using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserNamePassValidator
{
    public class UserNamePassValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null) { throw new ArgumentNullException(); }
            if (!(userName == "CiiMac" && password == "1234")) { throw new FaultException("Incorrect Username or Password"); }
        }
    }
}
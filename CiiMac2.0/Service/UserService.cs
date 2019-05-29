using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Controllers;
using Model.DatabaseModels;

namespace Service
{
    public class UserService : IUserService
    {
        public User CreateUser(User user, string password)
        {
            UserCtr ctr = new UserCtr();
            try
            {
                return ctr.CreateUser(user, password);
            }
            catch (FaultException)
            {
                throw;
            }
        }
    }
}

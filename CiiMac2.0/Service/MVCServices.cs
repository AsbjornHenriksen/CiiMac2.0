using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Controllers;
using Model.DatabaseModels;
using Model.Models;

namespace Service
{
    public class MVCServices : IMVCServices, ICompanyService, IUserService
    {
        UpdateDatabaseCtr companyCtr = new UpdateDatabaseCtr();
        UserCtr userCtr = new UserCtr();

        public Company ReturnCompanyIfLoginIsCorrect(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user, string password)
        {
            try
            {
                return userCtr.CreateUser(user, password);
            }
            catch (FaultException)
            {
                throw;
            }
        }

        public ListOfCollections GetList()
        {
            throw new NotImplementedException();
        }



      
    }
}

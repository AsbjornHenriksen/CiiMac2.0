using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BusinessLogic;
using BusinessLogic.Controllers; 
using Model.Models;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        UpdateDatabaseCtr updateDatabaseCtr;

        public CompanyService()
        {
            updateDatabaseCtr = new UpdateDatabaseCtr();
        }

        public ListOfCollections GetList()
        {
            GetListOfCompanies getListOfCompanies = new GetListOfCompanies();
            return getListOfCompanies.GetListOfCustomers();
        }

        public void UpdateDatabase()
        {
            updateDatabaseCtr.UpdateDatabase(); 
        }
    }
  
}

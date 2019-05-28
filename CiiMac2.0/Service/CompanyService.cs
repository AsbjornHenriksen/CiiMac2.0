using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Controllers; 
using Model.Models;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        public ListOfCollections GetList()
        {
            GetListOfCompanies getListOfCompanies = new GetListOfCompanies();
            return getListOfCompanies.GetListOfCustomers();
        }

        public void UpdateDatabase()
        {
            UpdateDatabaseCtr updateDatabaseCtr = new UpdateDatabaseCtr();
            updateDatabaseCtr.UpdateDatabase();  
        }
    }
}

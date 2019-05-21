using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.API_Connection;
using Model; 

namespace BusinessLogic
{
    public class GetCompany
    {
        APIConnector APIConnector;
        public GetCompany()
        {
            APIConnector = new APIConnector();
        }
        public Company GetCompanyTest()
        {
            Company company = new Company(); 
            return (Company)APIConnector.GetJsonFromApiAsync("customers", company).Result;
        }

    }
}

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
        public List<Company> GetCompanyTest()
        {
            return (List<Company>)APIConnector.GetJsonFromApiAsync("customers").Result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Model;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        GetCompany companyCtr = new GetCompany(); 
        public IEnumerable<Company> GetCompany()
        {
            return companyCtr.GetCompanyTest();  
        }
    }
}

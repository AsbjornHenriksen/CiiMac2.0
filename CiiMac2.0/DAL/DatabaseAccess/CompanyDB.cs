using Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseAccess
{
    public class CompanyDB
    {
        DBContext dBContext; 
        public CompanyDB()
        {
            dBContext = new DBContext();
        }

        private Company GetCompanyOnEmail(string email)
        {
           return dBContext.Companies.Where(c => c.Email == email).First();
        }

        public Company ReturnCompanyIfLoginIsCorrect(string email, string password , Func<Company, string , Company> decrypt)
        {
           Company company = GetCompanyOnEmail(email);
            if (company != null)
            {
               return decrypt(company, password);
            }
            return null;
        }

   

    }
}

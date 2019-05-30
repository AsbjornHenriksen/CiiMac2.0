using DAL.DatabaseAccess;
using Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
   public class CompanyCtr
    {
        CompanyDB companyDB;
        PasswordHashAndSalt passwordHashAndSalt; 
        public CompanyCtr()
        {
            companyDB = new CompanyDB();
            passwordHashAndSalt = new PasswordHashAndSalt(); 
        }

        public Company ReturnCompanyIfLoginIsCorrect(string email , string password) {

           return companyDB.ReturnCompanyIfLoginIsCorrect(email, password, passwordHashAndSalt.Decrypt);

        }
    }
}

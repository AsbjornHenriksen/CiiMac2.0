using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BusinessLogic;
using BusinessLogic.Controllers;
using Model.DatabaseModels;
using Model.Models;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        CompanyCtr companyCtr; 
        public CompanyService()
        {
            companyCtr = new CompanyCtr();
        }
    
      

        public Company ReturnCompanyIfLoginIsCorrect(string email, string password)
        {
           return companyCtr.ReturnCompanyIfLoginIsCorrect(email, password); 
        }

     
    }
  
}


using DAL.MergeModels;
using Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseAccess
{
 
    public class UpdateDatabase
    {
        DBContext context;
        MergeCompany merge;
        public UpdateDatabase()
        {
            context = new DBContext();
            merge = new MergeCompany();
        }


        private bool CheckIfCompanyAlreadyExist(long customerNumber)
        {

           
            if (context.Companies.Any(o => o.CustomerNumber == customerNumber))
            {
                return true;
            }
            return false;

        }




        private void InsertNewCompanies(byte[] completePassword, byte[] passwordSalt, Company company)
        {

       
                    if (!CheckIfCompanyAlreadyExist(company.CustomerNumber))
                    {
                        company.Level = Convert.ToInt32(Level.Company);
                        company.CompletePassword = completePassword;
                        company.PasswordSalt = passwordSalt;
                    }
                    context.Companies.Add(company); 
         }

        private void UpdateCompaniesFromApi(Company company)
        {
        
                    if (CheckIfCompanyAlreadyExist(company.CustomerNumber))
                    {
                        context.Companies.Add(company); 
                    }

        }

        public void UpdateDatabaseCreateAndUpdate(byte[] completePassword, byte[] passwordSalt) {
            using (var context = new DBContext())
            {
                foreach (Company company in merge.MergeLoginDatabaseModelWithApiCollection())
                {
                    InsertNewCompanies(completePassword, passwordSalt, company);
                    UpdateCompaniesFromApi(company);
                }
                context.SaveChanges();
            }
        }

    }

}

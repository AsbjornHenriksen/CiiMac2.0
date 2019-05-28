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




        private void InsertNewCompanies(byte[] completePassword, byte[] passwordSalt, Company company, DBContext dBContext)
        {

       
                    if (!CheckIfCompanyAlreadyExist(company.CustomerNumber))
                    {
                        company.Level = Convert.ToInt32(Level.Company);
                        company.CompletePassword = completePassword;
                        company.PasswordSalt = passwordSalt;
                    }
                    dBContext.Companies.Add(company); 
         }

        private void UpdateCompaniesFromApi(Company company, DBContext dBContext)
        {
        
                    if (CheckIfCompanyAlreadyExist(company.CustomerNumber))
                    {
                        Company com = dBContext.Companies.Where(x => x.CustomerNumber == company.CustomerNumber).FirstOrDefault();
                        com = company; 
                        
               
                    }

        }

        public void UpdateDatabaseCreateAndUpdate(byte[] completePassword, byte[] passwordSalt) {

            using (var transaction = new System.Transactions.TransactionScope())
            {
                using (var context = new DBContext())
            {
                foreach (Company company in merge.MergeLoginDatabaseModelWithApiCollection())
                {
                    InsertNewCompanies(completePassword, passwordSalt, company, context);
                    UpdateCompaniesFromApi(company, context);
                }
                context.SaveChanges();
            }
                transaction.Complete();
            }
        }

    }

}

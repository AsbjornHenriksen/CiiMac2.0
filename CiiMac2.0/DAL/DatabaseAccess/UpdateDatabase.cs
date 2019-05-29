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




        private void InsertNewCompanies(Func<string, Dictionary<string, byte[]>> passwordDic, Func<string> temporaryPassword,Action<Company, string> sendMail, Company company, DBContext dBContext)
        {

       
                    if (!CheckIfCompanyAlreadyExist(company.CustomerNumber))
                    {
                         string temp = temporaryPassword();
                         Dictionary<string, byte[]> dic = passwordDic(temp);
                         byte[] passwordSalt = dic["passwordSalt"];
                         byte[] completePassword = dic["completePassword"];


                        company.Level = Convert.ToInt32(Level.Company);
                        company.CompletePassword = completePassword;
                        company.PasswordSalt = passwordSalt;
                        dBContext.Companies.Add(company);
                        // sender mail inden det er blevet tiljøjet til databasen , IKKE GODT , det skal være efter. 
                        sendMail(company, temp);
                        
                    }
                    
        }

        private void UpdateCompaniesFromApi(Company company, DBContext dBContext)
        {
        
                    if (CheckIfCompanyAlreadyExist(company.CustomerNumber))
                    {
                      Company com = dBContext.Companies.Where(c => c.CustomerNumber == company.CustomerNumber).First();
                      com.Name = company.Name;
                      com.CorporateIdentificationNumber = company.CorporateIdentificationNumber;
                      com.Address = company.Address;
                      com.Phone = company.Phone;
                      com.Email = company.Email; 
                    
                    }

        }

        public void UpdateDatabaseCreateAndUpdate(Func<string, Dictionary<string, byte[]>> passwordDic,  Func<string> temporaryPassword, Action<Company, string> sendMail) {

            using (var transaction = new System.Transactions.TransactionScope())
            {
                using (var context = new DBContext())
            {
                foreach (Company company in merge.MergeLoginDatabaseModelWithApiCollection())
                {
                    InsertNewCompanies(passwordDic, temporaryPassword,sendMail, company, context);
                    UpdateCompaniesFromApi(company, context);
                }
                    context.SaveChanges();

                }
                transaction.Complete();
            }
        }

    }

}

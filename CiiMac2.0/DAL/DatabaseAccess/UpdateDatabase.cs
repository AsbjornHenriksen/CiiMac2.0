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

       
                    if (!CheckIfCompanyAlreadyExist(company.CustomerNumber) && company.Email != null)
                    {
                        if (company.City.PostalCode != "") {

                            City city = dBContext.Cities.Where(c => c.PostalCode == company.City.PostalCode).SingleOrDefault();
                            if (city != null)
                            {
                                company.CityId = city.CityId;
                            }
                            else
                            {
                                company.City.CityId = Guid.NewGuid();
                                company.CityId = company.City.CityId;

                            }
                        }




                        if (company.Country.CountryName != "")
                        {

                            Country country = dBContext.Countries.Where(c => c.CountryName == company.Country.CountryName).SingleOrDefault();
                            if (country != null)
                            {
                                company.CountryId = country.CountryId;
                            }
                            else
                            {
                                company.Country.CountryId = Guid.NewGuid();
                                company.CountryId = company.Country.CountryId;

                            }
                        }





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
                      City city = dBContext.Cities.Where(c => c.PostalCode == company.City.PostalCode).First();
                      Country country = dBContext.Countries.Where(c => c.CountryName == company.Country.CountryName).First();
                      Company com = dBContext.Companies.Where(c => c.CustomerNumber == company.CustomerNumber).First();
                      com.Name = company.Name;
                      com.CorporateIdentificationNumber = company.CorporateIdentificationNumber;
                      com.Address = company.Address;
                      com.Phone = company.Phone;
                      com.Email = company.Email;
                if (city == null)
                {
                    
                    com.City.CityId = company.CityId;
                    com.City.CityName = company.City.CityName;
                    com.City.PostalCode = company.City.PostalCode;

                }
                else {
                    com.City.CityId = city.CityId;
                    com.City.CityName = city.CityName;
                    com.City.PostalCode = city.PostalCode;

                }
                if (country == null)
                {

                    com.Country.CountryId = company.CountryId;
                    com.Country.CountryName = company.Country.CountryName;

                }
                else {

                    com.Country.CountryId = country.CountryId;
                    com.Country.CountryName = country.CountryName;

                }

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
                    //UpdateCompaniesFromApi(company, context);
                }
                    context.SaveChanges();

                }
                transaction.Complete();
            }
        }

    }

}

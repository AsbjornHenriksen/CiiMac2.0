using DAL.API_Connection;
using Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MergeModels
{
    public class MergeCompany
    {
        City city; 
        DeserializeJsonToObjects deserializeJsonToObjects;
        public MergeCompany()
        {
            deserializeJsonToObjects = new DeserializeJsonToObjects(); 
        }
        public List<Company> MergeLoginDatabaseModelWithApiCollection()
        {
            List<Company> listWithCompanies = new List<Company>(); 

            foreach (var field in deserializeJsonToObjects.GetListOfCollections("customers").Collection)
            {
               
                City city = new City { CityName = field.City , PostalCode = field.Zip  };
             
                Country country = new Country { CountryName = field.Country };
                Company company = new Company
                {
                    CustomerNumber = field.CustomerNumber,
                    Name = field.Name,
                    CorporateIdentificationNumber = field.CorporateIdentificationNumber,
                    Address = field.Address,
                    Phone = field.TelephoneAndFaxNumber,
                    Email = field.Email,
                 

                
                    
                };
                company.City = city;
                company.Country = country; 
              

               listWithCompanies.Add(company); 


                
            }

            return listWithCompanies; 
            
        }

    }
}

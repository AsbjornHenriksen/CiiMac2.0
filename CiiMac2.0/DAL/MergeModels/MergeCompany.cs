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
                Company company = new Company
                {
                    CustomerNumber = field.CustomerNumber,
                    Name = field.Name,
                    CorporateIdentificationNumber = field.CorporateIdentificationNumber, 
                    Address = field.Address,
                    Phone = field.TelephoneAndFaxNumber,
                    Email = field.Email
                  
                };

               listWithCompanies.Add(company); 


                
            }

            return listWithCompanies; 
            
        }

    }
}

using DAL.API_Connection;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GetListOfCompanies
    {
        public ListOfCollections GetListOfCustomers()
        {
            DeserializeJsonToObjects deserializeJsonToObjects = new DeserializeJsonToObjects();
            return deserializeJsonToObjects.GetListOfCollections("customers");
        }
        
          
    }
}

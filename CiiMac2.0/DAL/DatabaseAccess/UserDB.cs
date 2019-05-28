using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseAccess
{
    public class UserDB
    {
        DBContext dbContext; 
        public UserDB()
        {
            dbContext = new DBContext(); 
        }

        public void CreateUser()
        {
            
        }
    }
}

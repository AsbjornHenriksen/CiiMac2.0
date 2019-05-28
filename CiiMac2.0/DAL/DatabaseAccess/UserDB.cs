using Model.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseAccess
{
    public class UserDB
    {
        public UserDB()
        {
        }

        public User CreateUser(User user)
        {
            using (DBContext dbCon = new DBContext())
            {
                user.Id = Guid.NewGuid();
                user.Level = (int)Level.User;
                dbCon.Users.Add(user);

                dbCon.SaveChanges();
            }
            return user;
        }

        public User GetUser(Guid id)
        {
            using (DBContext dbCon = new DBContext())
            {
              return dbCon.Users.Where(l => l.Id == id).FirstOrDefault(); 
            } 
        }
    }
}


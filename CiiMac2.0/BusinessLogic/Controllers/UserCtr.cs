using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DatabaseAccess;
using Model.DatabaseModels;

namespace BusinessLogic.Controllers
{
    public class UserCtr
    {
        UserDB userDB;
        PasswordHashAndSalt passwordHashAndSalt;
        public UserCtr()
        {
            userDB = new UserDB();
            passwordHashAndSalt = new PasswordHashAndSalt();
        }

        public User CreateUser(User user, string password)
        {
            Dictionary<string, byte[]> dict = passwordHashAndSalt.HashAndSalt(password);
            byte[] passwordSalt = dict["passwordSalt"];
            byte[] completePassword = dict["completePassword"];

            user.PasswordSalt = passwordSalt;
            user.CompletePassword = completePassword;

            userDB.CreateUser(user);
            return userDB.GetUser(user.Id);

        }

    }
}

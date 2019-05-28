using DAL.DatabaseAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class UpdateDatabaseCtr
    {
        PasswordHashAndSalt passwordHashAndSalt;
        UpdateDatabase updateDB;

        public UpdateDatabaseCtr()
        {
            passwordHashAndSalt = new PasswordHashAndSalt();
            updateDB = new UpdateDatabase();
        }

        public void UpdateDatabase()
        {
            string temp = passwordHashAndSalt.GenerateTemporaryPassword(10);
            Dictionary<string, byte[]> dic = passwordHashAndSalt.HashAndSalt(temp);
            byte[] passwordSalt = dic["passwordSalt"];
            byte[] completePassword = dic["completePassword"];

            updateDB.UpdateDatabaseCreateAndUpdate(completePassword, passwordSalt);


        }

    }
}

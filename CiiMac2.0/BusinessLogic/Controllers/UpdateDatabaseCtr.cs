using DAL.DatabaseAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BusinessLogic.Controllers
{
    public class UpdateDatabaseCtr
    {
         

        PasswordHashAndSalt passwordHashAndSalt;
        UpdateDatabase updateDB;
        SendTemperaryPasswordToCompany sendTemperaryPasswordToCompany;


        public UpdateDatabaseCtr()
        {
            passwordHashAndSalt = new PasswordHashAndSalt();
            updateDB = new UpdateDatabase();
            sendTemperaryPasswordToCompany = new SendTemperaryPasswordToCompany(); 
        }

        public void UpdateDatabase()
        {
             updateDB.UpdateDatabaseCreateAndUpdate(passwordHashAndSalt.HashAndSalt, passwordHashAndSalt.GenerateTemporaryPassword,sendTemperaryPasswordToCompany.SendPasswordToCompanyEmail);
        }

       
       
     



    }
}

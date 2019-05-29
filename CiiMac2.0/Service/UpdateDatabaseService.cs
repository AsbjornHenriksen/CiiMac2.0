using BusinessLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UpdateDatabaseService" in both code and config file together.
    public class UpdateDatabaseService : IUpdateDatabaseService
    {
        UpdateDatabaseCtr updateDatabaseCtr;
        public UpdateDatabaseService()
        {

            updateDatabaseCtr = new UpdateDatabaseCtr();
        }
        public void UpdateDatabase()
        {
            updateDatabaseCtr.UpdateDatabase();
        }
    }
}

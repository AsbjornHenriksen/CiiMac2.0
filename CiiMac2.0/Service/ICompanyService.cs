﻿using Model.DatabaseModels;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetListOfCompanies" in both code and config file together.
    [ServiceContract]
    public interface ICompanyService
    {
       
        [OperationContract]
        Company ReturnCompanyIfLoginIsCorrect(string email, string password);

    }
}



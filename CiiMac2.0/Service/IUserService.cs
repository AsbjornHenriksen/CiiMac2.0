﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model.DatabaseModels;

namespace Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User CreateUser(User user, string password);
    }
}

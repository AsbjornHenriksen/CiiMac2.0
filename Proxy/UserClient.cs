using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Proxy.MVCReferencesWCF;

namespace Proxy
{
    public class UserClient : ClientBase<IUserService>, IUserService
    {
        public User CreateUser(User user, string password)
        {
            try
            {
                return Channel.CreateUser(user, password);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Task<User> CreateUserAsync(User user, string password)
        {
            return Channel.CreateUserAsync(user, password);
        }
    }
}

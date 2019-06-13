using Proxy.MVCReferencesWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class CompanyClient : ClientBase<ICompanyService>, ICompanyService
    {
        //public ListOfCollections GetList()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ListOfCollections> GetListAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Collection1 ReturnCompanyIfLoginIsCorrect(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Collection1> ReturnCompanyIfLoginIsCorrectAsync(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}

        Company ICompanyService.ReturnCompanyIfLoginIsCorrect(string email, string password)
        {
            throw new NotImplementedException();
        }

        Task<Company> ICompanyService.ReturnCompanyIfLoginIsCorrectAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

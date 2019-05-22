using System;
using System.ServiceModel.Web;

namespace Host
{
    class Program
    {

        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Service.CompanyService));

            host.Open();
            Console.WriteLine("Host started @ " + DateTime.Now.ToString());
            DisplayHost(host);
            Console.ReadLine();
            host.Close();
        }

        private static void DisplayHost(WebServiceHost host)

        {
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine($"Address: {se.Address}");
                Console.WriteLine($"Binding: { se.Binding}");
                Console.WriteLine($"Contract: {se.Contract}");

            }
            Console.WriteLine("------------------");
        }
    }
}

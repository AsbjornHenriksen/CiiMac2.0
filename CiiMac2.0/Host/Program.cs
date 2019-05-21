using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
      
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(WebRestExerciseService));

            host.Open();
            Console.WriteLine("Host started @ " + DateTime.Now.ToString());
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

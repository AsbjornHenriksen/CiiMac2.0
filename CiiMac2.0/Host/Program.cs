using BusinessLogic.Controllers;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using System.Timers;

namespace Host
{
    class Program
    {
        static UpdateDatabaseCtr updateDatabaseCtr;
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Service.MVCServices));

            host.Open();
            Console.WriteLine("Host started @ " + DateTime.Now.ToString());

            Update(); 

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

        private static void Update()
        {
            updateDatabaseCtr = new UpdateDatabaseCtr();
            updateDatabaseCtr.UpdateDatabase();
        }


       
    }
}

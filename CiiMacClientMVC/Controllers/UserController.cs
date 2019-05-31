using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;


namespace CiiMacClientMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult InsertUser()
        {
            //try
            //{
            //    UserClient userClient = new UserClient();

            //    userClient.CreateUser(user, password);
            //}
            //catch (FaultException ex)
            //{
            //    ex.StackTrace.ToString();
            //}

            return View();
        }

    }
}
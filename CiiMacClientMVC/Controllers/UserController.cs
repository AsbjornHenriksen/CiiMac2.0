using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy;
using Proxy.MVCServiceRef;

namespace CiiMacClientMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        
        public ActionResult UserHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertUser(User user, string password)
        {
            UserClient userClient = new UserClient();

            userClient.CreateUser(user, password);

            return View(); 
        }

    }
}
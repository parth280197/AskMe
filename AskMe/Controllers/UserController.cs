using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AskMe.BusinessLayer;

namespace AskMe.Controllers
{
    public class UserController : Controller
    {
        UserBusinessLayer user = new UserBusinessLayer();
        // GET: User
        public ActionResult Index()
        {
            var users = user.GetUsers();
            return View();
        }
    }
}
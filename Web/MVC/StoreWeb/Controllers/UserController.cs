using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult SignIn()
        {
            return View();
        }

        public IActionResult SignIn(string username, string password)
        {
            return View();
        }

        public ViewResult SignUp()
        {
            return View();
        }

        public IActionResult SignUp(string name, string email, string username, string password, int locationId)
        {
            return View();
        }

    }
}
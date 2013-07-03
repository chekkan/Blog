using System;
using System.Web.Mvc;
using Chekkan.Blog.Core;
using Chekkan.Blog.Data.Sql;

namespace Chekkan.Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController()
            : this(new SqlUserService())
        { }

        public AccountController(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException("userService");
            this.userService = userService;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (userService.IsValid(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}



using System.Web.Mvc;

namespace Chekkan.Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

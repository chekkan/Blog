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
        public ViewResult Login(string Email, string Password)
        {
            throw new System.NotImplementedException();
        }
    }
}

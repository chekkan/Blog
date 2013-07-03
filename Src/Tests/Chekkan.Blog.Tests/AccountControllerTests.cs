using System.Web.Mvc;
using Xunit;
using Chekkan.Blog.Web.Controllers;
using System.Linq;

namespace Chekkan.Blog.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public void SutIsaController()
        {
            var sut = new AccountController();
            Assert.IsAssignableFrom<Controller>(sut);
        }

        [Fact]
        public void LoginMethodReturnsViewResult()
        {
            var sut = new AccountController();
            Assert.IsAssignableFrom<ViewResult>(sut.Login());
        }

        [Fact]
        public void LoginMethodOverrideIsDecoratedWithHttpPostAttribute()
        {
            var method = typeof(AccountController)
                .GetMethod("Login", new System.Type[] { typeof(string), typeof(string) });
            var attribute = method.GetCustomAttributes(typeof(HttpPostAttribute), false)
                .Cast<HttpPostAttribute>()
                .SingleOrDefault();

            Assert.NotNull(attribute);
        }
    }
}

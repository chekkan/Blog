using System.Web.Mvc;
using Xunit;
using Chekkan.Blog.Web.Controllers;

namespace Chekkan.Tests
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
    }
}

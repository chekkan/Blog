using Xunit;
using Chekkan.Blog.Web.Controllers;
using System.Web.Mvc;

namespace Chekkan.Tests
{
    public class HomeControllerTests
    {
        private HomeController sut;

        public HomeControllerTests()
        {
            sut = new HomeController();
        }

        [Fact]
        public void SutIsaController()
        {
            Assert.IsAssignableFrom<Controller>(sut);
        }

        [Fact]
        public void IndexMethodReturnsAViewResult()
        {
            Assert.IsAssignableFrom<ViewResult>(sut.Index());
        }
    }
}

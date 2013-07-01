using Xunit;
using Chekkan.Blog.Web.Controllers;
using System.Web.Mvc;

namespace Chekkan.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void SutIsaController()
        {
            var sut = new HomeController();
            Assert.IsAssignableFrom<Controller>(sut);
        }
    }
}

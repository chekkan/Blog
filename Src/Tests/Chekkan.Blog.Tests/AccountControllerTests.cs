using System;
using System.Web.Mvc;
using Xunit;
using Chekkan.Blog.Web.Controllers;
using System.Linq;
using Xunit.Extensions;
using Chekkan.Blog.Core;
using Moq;

namespace Chekkan.Blog.Tests
{
    public class AccountControllerTests
    {
        private AccountController sut;
        private Mock<IUserService> mockUserService;

        public AccountControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            sut = new AccountController(mockUserService.Object);
        }

        [Fact]
        public void SutIsaController()
        {
            Assert.IsAssignableFrom<Controller>(sut);
        }

        [Fact]
        public void SutThrowsExceptionForNullUserService()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>( () => new AccountController(null));
            Assert.Equal("userService", ex.ParamName);
        }

        [Fact]
        public void LoginMethodsReturnsViewResult()
        {
            Assert.IsType<ViewResult>(sut.Login());
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

        [Fact]
        public void LoginOverloadReturnsActionResult()
        {
            Assert.IsAssignableFrom<ActionResult>(sut.Login(string.Empty, string.Empty));
        }

        [Theory]
        [InlineData("foo", "bar")]
        [InlineData("baz", "tar")]
        public void LoginMethodRedirectsValidLoginToHomeIndex(
            string email,
            string password)
        {
            mockUserService.Setup(u => u.IsValid(email, password)).Returns(true);

            ActionResult result = sut.Login(email, password);

            var redirectResult = (RedirectToRouteResult)result;

            Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal("Home", redirectResult.RouteValues["controller"]);
            Assert.Equal("Index", redirectResult.RouteValues["action"]);
        }

        [Theory]
        [InlineData("foo", "bar")]
        [InlineData("baz", "tar")]
        public void LoginMethodReturnLoginViewAfterInvalidLogin(
            string email,
            string password)
        {
            mockUserService.Setup(u => u.IsValid(email, password)).Returns(false);

            var result = sut.Login(email, password);
            var viewResult = (ViewResult)result;
            
            Assert.IsType<ViewResult>(result);
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName), "view name is not empty");
            //Assert.Same(user,viewResult.ViewData.Model);
            //Assert.Equal(false,viewResult.ViewData.ModelState.IsValid);
        }
    }
}

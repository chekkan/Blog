using System;
using System.Web.Mvc;
using Castle.MicroKernel;
using Chekkan.Blog.Web.Plumbing;
using Moq;
using Xunit;

namespace Chekkan.Blog.Tests
{
    public class WindsorControllerFactoryTests
    {
        private Mock<IKernel> mockKernel;
        private WindsorControllerFactory sut;

        public WindsorControllerFactoryTests()
        {
            mockKernel = new Mock<IKernel>();
            sut = new WindsorControllerFactory(mockKernel.Object);

        }

        [Fact]
        public void Sut_is_a_IControllerFactory()
        {
            Assert.IsAssignableFrom<IControllerFactory>(sut);
            Assert.IsAssignableFrom<DefaultControllerFactory>(sut);
        }

        [Fact]
        public void Sut_throws_ArgumnetNullException_given_null_parameter()
        {
            var ex = Assert.Throws<ArgumentNullException>( 
                () => new WindsorControllerFactory(null));
            Assert.Equal("kernel", ex.ParamName);
        }

        [Fact]
        public void ReleaseController_calls_ReleaseComponent_method_on_kernel()
        {
            var stubController = new Mock<IController>();

            sut.ReleaseController(stubController.Object);
            
            mockKernel.Verify(k => k.ReleaseComponent(stubController.Object),
                Times.Once());
        }
    }
}

using System;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.Windsor;
using Xunit;
using Chekkan.Blog.Core.Castle.Installers;

namespace Chekkan.Blog.Tests
{
    public class ControllersInstallerTests
    {
        private IWindsorContainer containerWithControllers;

        public ControllersInstallerTests()
        {
            containerWithControllers = new WindsorContainer()
                .Install(new ControllersInstaller());
        }

        [Fact]
        public void All_Controllers_Implement_IController()
        {
            var allHandlers = GetAllHandlers(containerWithControllers);
            var controllerHandlers = GetHandlersFor(typeof(IController), containerWithControllers);

            Assert.NotEmpty(allHandlers);
            Assert.Equal(allHandlers, controllerHandlers);
        }

        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }
    }
}

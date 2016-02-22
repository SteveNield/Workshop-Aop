using System.Reflection;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Moq;
using NUnit.Framework;
using Workshop.Aop.Calculator.Logging;

namespace Workshop.Aop.Test.Unit
{
    [TestFixture]
    public class LoggingAspectTests
    {
        [Test]
        public void Logs_Method_Name_With_Arguments_Before_Invocation()
        {
            var expectedLogMessage = "m_inv:Test Method,m_args:1,2";

            var invokedMethodInfo = new Mock<MethodInfo>();
            invokedMethodInfo.Setup(m => m.Name).Returns("Test Method");

            var invocation = new Mock<IInvocation>();
            invocation.Setup(m => m.Method).Returns(invokedMethodInfo.Object);
            invocation.Setup(m => m.Arguments).Returns(new object[] { 1, 2 });

            var logger = new Mock<ILogger>();
            logger.Setup(m => m.Info(It.IsAny<string>()));

            var loggingAspect = new LoggingAspect(logger.Object);
            loggingAspect.Intercept(invocation.Object);

            logger.Verify(m => m.Info(expectedLogMessage), Times.Once());
        }

        [Test]
        public void Proceeds_With_Invocation()
        {
            var invokedMethodInfo = new Mock<MethodInfo>();
            invokedMethodInfo.Setup(m => m.Name).Returns("Test Method");

            var invocation = new Mock<IInvocation>();
            invocation.Setup(m => m.Method).Returns(invokedMethodInfo.Object);
            invocation.Setup(m => m.Proceed());

            var logger = new Mock<ILogger>();
            logger.Setup(m => m.Info(It.IsAny<string>()));

            var loggingAspect = new LoggingAspect(logger.Object);
            loggingAspect.Intercept(invocation.Object);

            invocation.Verify(m => m.Proceed(), Times.Once());
        }
    }
}

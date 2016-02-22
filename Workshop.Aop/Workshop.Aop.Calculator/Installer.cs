using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Workshop.Aop.Calculator.Logging;

namespace Workshop.Aop.Calculator
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<LoggingAspect>(),
                Component.For<ICalculator>()
                    .ImplementedBy<SimpleCalculator>()
                    .Interceptors<LoggingAspect>(),
                Component.For<ILogger>()
                    .ImplementedBy<Logger>()
            );
        }
    }
}

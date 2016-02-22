using System;
using Castle.Core;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Workshop.Aop.Calculator.Logging
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

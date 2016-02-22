using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace Workshop.Aop.Calculator.Logging
{
    public class LoggingAspect : IInterceptor
    {
        private readonly ILogger _logger;

        public LoggingAspect(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.Info($"m_inv:{invocation.Method.Name}");

            invocation.Proceed();
        }
    }
}

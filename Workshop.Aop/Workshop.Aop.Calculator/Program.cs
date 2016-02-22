using System;
using Castle.Windsor;
using Workshop.Aop.Calculator.Logging;

namespace Workshop.Aop.Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var iocContainer = new WindsorContainer();
            iocContainer.Install(new Installer());

            var calculator = iocContainer.Resolve<ICalculator>();

            var result = calculator.Add(1, 1);

            Console.WriteLine($"Result of adding 1 and 1 is: {result}");

            Console.ReadLine();
        }
    }
}

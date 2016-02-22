using NUnit.Framework;
using Workshop.Aop.Calculator;

namespace Workshop.Aop.Test.Unit
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        [Test]
        public void Add_Does_Return_2_When_Passed_1_And_1()
        {
            ICalculator calculator = new SimpleCalculator();

            var result = calculator.Add(1, 1);

            Assert.AreEqual(2, result);
        }
    }
}

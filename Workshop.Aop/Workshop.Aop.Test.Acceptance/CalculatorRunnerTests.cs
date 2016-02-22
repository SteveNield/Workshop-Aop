using System.Configuration;
using System.IO;
using NUnit.Framework;
using Workshop.Aop.Calculator;

namespace Workshop.Aop.Test.Acceptance
{
    [TestFixture]
    public class CalculatorRunnerTests
    {
        [Test]
        public void Logs_Add_Method_Call_To_Log_File()
        {
            var logFileName = ConfigurationManager.AppSettings.Get("LogFileName");
            var expectedMessage = "m_inv:Add,m_args:1,1";

            DeleteLogFile(logFileName);

            Program.Main(new string[] {});

            var contents = File.ReadAllText(logFileName);

            Assert.AreEqual(expectedMessage, contents);

            DeleteLogFile(logFileName);
        }

        private void DeleteLogFile(string logFileName)
        {
            File.Delete(logFileName);
        }
    }
}

namespace Kalbe.Calculator.UnitTest
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;
    using Moq;

    using Kalbe.Calculator.WebApp;

    [TestFixture]
    public class CalculatorControllerTest
    {
        protected CalculatorController _controller;

        [SetUp]
        public void Setup()
        {
            var loggerMoq = new Mock<ILogger<CalculatorController>>();
            var configMoq = new Mock<Iconfiguration>();

            _controller = new CalculatorController(loggerMoq.Object, configMoq.Object);
        }

        [Test]
        public void Calculate_Multiply()
        {
            string mode = "x";
            decimal val1 = 10;
            decimal val2 = 1.5;
            var result = _controller.Calculate(mode, val1, val2);


        }
    }
}
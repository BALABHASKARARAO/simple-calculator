namespace Kalbe.Calculator.UnitTest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;
    using Moq;

    using Kalbe.Calculator.WebApp.Controllers;

    [TestFixture]
    public class CalculatorControllerTest
    {
        protected CalculatorController _controller;

        [SetUp]
        public void Setup()
        {
            var loggerMoq = new Mock<ILogger<CalculatorController>>();
            var configMoq = new Mock<IConfiguration>();

            _controller = new CalculatorController(loggerMoq.Object, configMoq.Object);
        }

        [Test]
        public void Calculate_Multiply_10_15()
        {
            string mode = "x";
            decimal val1 = (decimal)10;
            decimal val2 = (decimal)15;
            decimal result = Calculate(mode, val1, val2);

            Assert.AreEqual(result, 150);
        }

        [Test]
        public void Calculate_Divide_20_4()
        {
            string mode = ":";
            decimal val1 = (decimal)20;
            decimal val2 = (decimal)4;
            decimal result = Calculate(mode, val1, val2);

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void Calculate_Add_99_3()
        {
            string mode = "+";
            decimal val1 = (decimal)99;
            decimal val2 = (decimal)3;
            decimal result = Calculate(mode, val1, val2);

            Assert.AreEqual(result, 102);
        }

        [Test]
        public void Calculate_Substract_27_16()
        {
            string mode = "-";
            decimal val1 = (decimal)27;
            decimal val2 = (decimal)16;
            decimal result = Calculate(mode, val1, val2);

            Assert.AreEqual(result, 11);
        }

        private decimal Calculate(string mode, decimal val1, decimal val2)
        {
            var result = _controller.Calculate(mode, val1, val2);
            decimal valueResult = (decimal)result.Value?.GetType().GetProperty("result")?.GetValue(result.Value, null);
            return valueResult;
        }
    }
}
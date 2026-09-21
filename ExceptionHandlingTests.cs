using CalculatorLib.Exceptions;
using CalculatorLib.Services;
using CalculatorLib.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class ExceptionHandlingTests
    {
        private ICalculationService _calcService;

        [TestInitialize]
        public void Setup()
        {
            _calcService = new CalculationService();
        }

        [TestMethod]
        public void Test_EmptyExpression_InformsUserAndContinues()
        {
            InvalidExpressionException ex = null;
            try
            {
                _calcService.Calculate("");
            }
            catch (InvalidExpressionException e)
            {
                ex = e;
            }

            Assert.IsNotNull(ex, "Ожидалось исключение InvalidExpressionException.");
            Assert.AreEqual("Выражение не может быть пустым.", ex.Message);

            string nextResult = _calcService.Calculate("5+5");
            Assert.AreEqual("10", nextResult);
        }

        [TestMethod]
        public void Test_DivideByZero_InformsUserAndContinues()
        {
            InvalidExpressionException ex = null;
            try
            {
                _calcService.Calculate("10/0");
            }
            catch (InvalidExpressionException e)
            {
                ex = e;
            }

            Assert.IsNotNull(ex, "Ожидалось исключение InvalidExpressionException.");
            Assert.AreEqual("Деление на ноль недопустимо.", ex.Message);

            string nextResult = _calcService.Calculate("20/4");
            Assert.AreEqual("5", nextResult);
        }

        [TestMethod]
        public void Test_WorkflowContinuity_AfterHandledException()
        {
            string errorMessage = string.Empty;
            bool wasHandled = false;

            try
            {
                _calcService.Calculate("2+*3");
            }
            catch (InvalidExpressionException ex)
            {
                wasHandled = true;
                errorMessage = ex.Message;
            }

            Assert.IsTrue(wasHandled, "Исключение InvalidExpressionException не было выброшено.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(errorMessage), "Сообщение об ошибке не должно быть пустым.");

            string validResult = _calcService.Calculate("10-3");
            Assert.AreEqual("7", validResult);
        }
    }
}
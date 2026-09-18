using CalculatorLib.Exceptions;
using CalculatorLib.Services;
using CalculatorLib.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Calculator
{
    [TestClass]
    public class CalculationServiceTests
    {
        private ICalculationService _calcService;
        private IHistoryService _historyService;

        [TestInitialize]
        public void Setup()
        {
            _calcService = new CalculationService();
            _historyService = new FileHistoryService();
        }
        [TestMethod]
        public void TestCalculate()
        {
            string expression = "2+2";

            string result = _calcService.Calculate(expression);
            _historyService.SaveResult(expression, result);

            Assert.AreEqual("4", result);
        }
        [TestMethod]
        public void TestLoadHistory()
        {
            _historyService.ClearHistory();
            string expression = "10*5";
            string result = _calcService.Calculate(expression);

            _historyService.SaveResult(expression, result);
            List<string> history = _historyService.LoadHistory();

            Assert.IsTrue(history.Count > 0);
            Assert.IsTrue(history[0].Contains("10*5 = 50"));
        }
        [TestMethod]
        public void TestCalculateEmptyExpression()
        {
            bool exceptionCaught = false;
            bool finallyExecuted = false;

            try
            {
                _calcService.Calculate("");
            }
            catch (InvalidExpressionException ex)
            {
                exceptionCaught = true;
                Assert.AreEqual("Выражение не может быть пустым.", ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Неожиданный тип исключения: {ex.GetType().Name}");
            }
            finally
            {
                finallyExecuted = true;
            }

            Assert.IsTrue(exceptionCaught, "Исключение InvalidExpressionException не было перехвачено.");
            Assert.IsTrue(finallyExecuted, "Блок finally не был выполнен.");
        }

        [TestMethod]
        public void TestCalculateDivideByZero()
        {
            bool exceptionCaught = false;

            try
            {
                _calcService.Calculate("10/0");
            }
            catch (CalculationDivisionByZeroException)
            {
                exceptionCaught = true;
            }
            finally
            {
            }

            Assert.IsTrue(exceptionCaught, "Исключение CalculationDivisionByZeroException не было перехвачено.");
        }
    }
}

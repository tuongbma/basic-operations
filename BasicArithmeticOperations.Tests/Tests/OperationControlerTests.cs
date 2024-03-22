using BasicArithmeticOperations.Controllers;
using BasicArithmeticOperations.Utils;
using BasicArithmeticOperations.Utils.Calculator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BasicArithmeticOperations.Tests.Tests
{
    public class OperationControlerTests
    {
        private OperationsController operationsController;
        private ICalculator _calculator;
        private ILogger<OperationsController> _logger;

        public OperationControlerTests()
        {
            _calculator = Helper.GetService<ICalculator>(); 
            _logger = Helper.GetService<ILogger<OperationsController>>();

            operationsController = new OperationsController(_logger, _calculator);
        }

        [Fact]
        public void Add_TwoSmallArguments_ReturnOkSum()
        {
            string aStr = "231231.5";
            string bStr = "2321.244";

            var a = decimal.Parse(aStr);
            var b = decimal.Parse(bStr);

            var actual = a + b;

            var resultAsync = operationsController.Add(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Add_TwoBigArguments_ReturnOkSum()
        {
            string aStr = "2312453534534534543534534534543534534534543534534543531";
            string bStr = "2321";

            var a = BigInteger.Parse(aStr);
            var b = BigInteger.Parse(bStr);

            var actual = a + b;

            var resultAsync = operationsController.Add(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Add_NotNumericArguments_ReturnBadRequest()
        {
            string aStr = "23124535345345345435345345334433424543534534534543534534543531bgffhgfhfg";
            string bStr = "2321!!3321&&";

            var resultAsync = operationsController.Add(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }


        [Fact]
        public void Subtract_TwoSmallArguments_ReturnOkSum()
        {
            string aStr = "231231.5";
            string bStr = "2321.244";

            var a = decimal.Parse(aStr);
            var b = decimal.Parse(bStr);

            var actual = a - b;

            var resultAsync = operationsController.Subtract(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Subtract_TwoBigArguments_ReturnOkSum()
        {
            string aStr = "2312453534534534543534534534543534534534543534534543531";
            string bStr = "2321";

            var a = BigInteger.Parse(aStr);
            var b = BigInteger.Parse(bStr);

            var actual = a - b;

            var resultAsync = operationsController.Subtract(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Subtract_NotNumericArguments_ReturnBadRequest()
        {
            string aStr = "23124535345345345435345345334433424543534534534543534534543531bgffhgfhfg";
            string bStr = "2321!!3321&&";

            var resultAsync = operationsController.Subtract(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }


        [Fact]
        public void Multiply_TwoSmallArguments_ReturnOkSum()
        {
            string aStr = "231231.5";
            string bStr = "2321.244";

            var a = decimal.Parse(aStr);
            var b = decimal.Parse(bStr);

            var actual = a * b;

            var resultAsync = operationsController.Multiply(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Multiply_TwoBigArguments_ReturnOkSum()
        {
            string aStr = "2312453534534534543534534534543534534534543534534543531";
            string bStr = "2321";

            var a = BigInteger.Parse(aStr);
            var b = BigInteger.Parse(bStr);

            var actual = a * b;

            var resultAsync = operationsController.Multiply(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Multiply_NotNumericArguments_ReturnBadRequest()
        {
            string aStr = "23124535345345345435345345334433424543534534534543534534543531bgffhgfhfg";
            string bStr = "2321!!3321&&";

            var resultAsync = operationsController.Multiply(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        public void Divide_TwoSmallArguments_ReturnOkSum()
        {
            string aStr = "231231.5";
            string bStr = "2321.244";

            var a = decimal.Parse(aStr);
            var b = decimal.Parse(bStr);

            var actual = a / b;

            var resultAsync = operationsController.Divide(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Divide_TwoBigArguments_ReturnOkSum()
        {
            string aStr = "2312453534534534543534534534543534534534543534534543531";
            string bStr = "2321";

            var a = BigInteger.Parse(aStr);
            var b = BigInteger.Parse(bStr);

            var actual = a / b;

            var resultAsync = operationsController.Divide(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(actual.ToString(), result.Value);
        }

        [Fact]
        public void Divide_NotNumericArguments_ReturnBadRequest()
        {
            string aStr = "23124535345345345435345345334433424543534534534543534534543531bgffhgfhfg";
            string bStr = "2321!!3321&&";

            var resultAsync = operationsController.Divide(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }


        [Fact]
        public void Divide_By0_ReturnBadRequests()
        {
            string aStr = "2312453534534534543534534533443342454";
            string bStr = "0";

            var resultAsync = operationsController.Divide(aStr, bStr);
            var result = resultAsync as ObjectResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }
    }
}

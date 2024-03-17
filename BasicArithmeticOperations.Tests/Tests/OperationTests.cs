using BasicArithmeticOperations.Utils;
using BasicArithmeticOperations.Utils.Calculator;

namespace BasicArithmeticOperations.Tests.Tests
{
    public class OperationTests
    {
        [Fact]
        public void Add_TwoDecimals_ReturnSum()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal firstNum = 3333;
            decimal secondNum = 1;
            var result = calculator.Add(firstNum, secondNum);

            decimal actual = firstNum + secondNum;

            Assert.Equal(actual, result);
        }

        [Fact]

        public void Add_TwoBigDecimals_ThrowException()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal firstNum = decimal.MaxValue;
            decimal secondNum = decimal.MaxValue;

            Assert.Throws<ArgumentException>(() => calculator.Add(firstNum, secondNum));
        }

        [Fact]
        public void Subtract_TwoDecimals_ReturnDifference()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal minuend = 123551;
            decimal subtrahend = 3222.23m;
            var result = calculator.Subtract(minuend, subtrahend);

            var actual = minuend - subtrahend;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Subtract_TwoSmallDecimals_ThrowException()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal minuend = decimal.MinValue;
            decimal subtrahend = decimal.MinValue;

            Assert.Throws<ArgumentException>(() => calculator.Add(minuend, subtrahend));
        }

        [Fact]
        public void Multiply_TwoDecimals_ReturnProduct()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal firstNum = 213.1m;
            decimal secondNum = 23;
            var result = calculator.Multiply(firstNum, secondNum);

            var actual = firstNum * secondNum;

            Assert.Equal(actual, result);
        }

        [Fact]

        public void Multiply_TwoBigDecimals_ThrowException()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal firstNum = decimal.MaxValue;
            decimal secondNum = decimal.MaxValue;

            Assert.Throws<ArgumentException>(() => calculator.Multiply(firstNum, secondNum));
        }

        [Fact]
        public void Divide_TwoDecimals_ReturnQuotient()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal dividend = 67575;
            decimal divisor = 322;
            var result = calculator.Divide(dividend, divisor);

            var actual = dividend / divisor;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowException()
        {
            var calculator = Helper.GetService<ICalculator>();

            decimal dividend = 43;
            decimal divisor = 0;

            Assert.Throws<ArgumentException>(() => calculator.Divide(dividend, divisor));
        }
    }
}
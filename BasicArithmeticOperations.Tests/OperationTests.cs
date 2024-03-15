using BasicArithmeticOperations.Utils;

namespace BasicArithmeticOperations.Tests
{
    public class OperationTests
    {
        [Fact]
        public void Add_TwoDecimals_ReturnSum()
        {
            decimal firstNum = 3333;
            decimal secondNum = 1;
            var result = Calculator.Add(firstNum, secondNum);

            decimal actual = firstNum + secondNum;

            Assert.Equal(actual, result);
        }

        [Fact]

        public void Add_TwoBigDecimals_ThrowException()
        {
            decimal firstNum = decimal.MaxValue;
            decimal secondNum = decimal.MaxValue;

            Assert.Throws<ArgumentException>(() => Calculator.Add(firstNum, secondNum));
        }

        [Fact]
        public void Subtract_TwoDecimals_ReturnDifference()
        {
            decimal minuend = 123551;
            decimal subtrahend = 3222.23m;
            var result = Calculator.Subtract(minuend, subtrahend);

            var actual = (decimal) minuend - subtrahend;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Subtract_TwoSmallDecimals_ThrowException()
        {
            decimal minuend = decimal.MinValue;
            decimal subtrahend = decimal.MinValue;

            Assert.Throws<ArgumentException>(() => Calculator.Add(minuend, subtrahend));
        }

        [Fact]
        public void Multiply_TwoDecimals_ReturnProduct()
        {
            decimal firstNum = 213.1m;
            decimal secondNum = 23;
            var result = Calculator.Multiply(firstNum, secondNum);

            var actual = firstNum * secondNum;

            Assert.Equal(actual, result);
        }

        [Fact]

        public void Multiply_TwoBigDecimals_ThrowException()
        {
            decimal firstNum = decimal.MaxValue;
            decimal secondNum = decimal.MaxValue;

            Assert.Throws<ArgumentException>(() => Calculator.Multiply(firstNum, secondNum));
        }

        [Fact]
        public void Divide_TwoDecimals_ReturnQuotient()
        {
            decimal dividend = 67575;
            decimal divisor = 322;
            var result = Calculator.Divide(dividend, divisor);

            var actual = dividend / divisor;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowException()
        {
            decimal dividend = 43;
            decimal divisor = 0;

            Assert.Throws<ArgumentException>(() => Calculator.Divide(dividend, divisor));
        }
    }
}
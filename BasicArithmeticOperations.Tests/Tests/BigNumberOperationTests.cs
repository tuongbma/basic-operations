using BasicArithmeticOperations.Utils;
using BasicArithmeticOperations.Utils.Calculator;
using System.Numerics;

namespace BasicArithmeticOperations.Tests
{
    public class BigNumberOperationTests
    {
        [Fact]
        public void Add_TwoBigIntergers_ReturnSum()
        {
            var calculator = Helper.GetService<ICalculator>();

            BigInteger firstNum = BigInteger.Parse("314345354456563564343242423223132213321342");
            BigInteger secNum = BigInteger.Parse("314345354456563564343242423342");

            var result = calculator.AddBigNumbers(firstNum, secNum);

            BigInteger actual = firstNum + secNum;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Subtract_TwoBigIntergers_ReturnDifference()
        {
            var calculator = Helper.GetService<ICalculator>();

            BigInteger minuend = BigInteger.Parse("3143453544563452324242563564343242423223132213321342");
            BigInteger subtrahend = BigInteger.Parse("31434535445656358864343242423342");

            var result = calculator.SubtractBigNumbers(minuend, subtrahend);

            var actual = minuend - subtrahend;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Multiply_TwoBigIntergers_ReturnProduct()
        {
            var calculator = Helper.GetService<ICalculator>();

            BigInteger firstNum = BigInteger.Parse("45553453535353");
            BigInteger secNum = BigInteger.Parse("9898798797898797978978979879789");

            var result = calculator.MultiplyBigNumbers(firstNum, secNum);

            var actual = firstNum * secNum;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Divide_TwoBigIntergers_ReturnQuotient()
        {
            var calculator = Helper.GetService<ICalculator>();

            BigInteger dividend = BigInteger.Parse("423423432423423423423423423423423432423423424");
            BigInteger divisor = BigInteger.Parse("1232");

            var result = calculator.DivideBigNumbers(dividend, divisor);

            var actual = dividend / divisor;

            Assert.Equal(actual, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowException()
        {
            var calculator = Helper.GetService<ICalculator>();

            BigInteger dividend = 476575673;
            BigInteger divisor = 0;

            Assert.Throws<ArgumentException>(() => calculator.DivideBigNumbers(dividend, divisor));
        }
    }

}
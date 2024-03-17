using System.Numerics;

namespace BasicArithmeticOperations.Utils.Calculator
{
    public interface ICalculator
    {
        public decimal Add(decimal firstNum, decimal secNum);
        public decimal Subtract(decimal minuend, decimal subtrahend);
        public decimal Multiply(decimal firstNum, decimal secNum);
        public decimal Divide(decimal dividend, decimal divisor);
        public BigInteger AddBigNumbers(BigInteger firstNum, BigInteger secNum);
        public BigInteger SubtractBigNumbers(BigInteger minuend, BigInteger subtrahend);
        public BigInteger MultiplyBigNumbers(BigInteger firstNum, BigInteger secNum);
        public BigInteger DivideBigNumbers(BigInteger dividend, BigInteger divisor);
    }
}

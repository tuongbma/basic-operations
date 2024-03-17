using BasicArithmeticOperations.Utils;
using System;
using System.Numerics;

namespace BasicArithmeticOperations.Utils.Calculator
{
    public class Calculator : ICalculator
    {
        public decimal Add(decimal firstNum, decimal secNum)
        {
            try
            {
                decimal result = firstNum + secNum;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }

        }

        public decimal Subtract(decimal minuend, decimal subtrahend)
        {
            try
            {
                decimal result = minuend - subtrahend;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }
        }

        public decimal Multiply(decimal firstNum, decimal secNum)
        {
            try
            {
                decimal result = firstNum * secNum;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }
        }

        public decimal Divide(decimal dividend, decimal divisor)
        {
            if (divisor == 0)
            {
                // division by 0
                throw new ArgumentException(Messages.DivisionByZero);
            }

            try
            {
                decimal result = dividend / divisor;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }
        }

        public BigInteger AddBigNumbers(BigInteger firstNum, BigInteger secNum)
        {
            try
            {
                BigInteger result = firstNum + secNum;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }

        }

        public BigInteger SubtractBigNumbers(BigInteger minuend, BigInteger subtrahend)
        {
            try
            {
                BigInteger result = minuend - subtrahend;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }
        }

        public BigInteger MultiplyBigNumbers(BigInteger firstNum, BigInteger secNum)
        {
            try
            {
                BigInteger result = firstNum * secNum;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }
        }

        public BigInteger DivideBigNumbers(BigInteger dividend, BigInteger divisor)
        {
            if (divisor == 0)
            {
                // division by 0
                throw new ArgumentException(Messages.DivisionByZero);
            }

            try
            {
                BigInteger result = dividend / divisor;
                return result;
            }
            catch
            {
                // result is out of value range
                throw new ArgumentException(Messages.RangeLimitExceeded);
            }
        }
    }
}

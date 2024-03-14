using BasicArithmeticOperations.Utils;
using System;

namespace BasicArithmeticOperations
{
    public static class Calculator
    {
        public static decimal Add(decimal firstNum, decimal secNum)
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

        public static decimal Subtract(decimal minuend, decimal subtrahend)
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

        public static decimal Multiply(decimal firstNum, decimal secNum)
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

        public static decimal Divide(decimal dividend, decimal divisor)
        {
            if (divisor == 0)
            {
                // division by 0
                throw new ArgumentException(Messages.DivisionByZero);
            }

            try
            {
                decimal result = dividend/ divisor;
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

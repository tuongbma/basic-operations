using BasicArithmeticOperations.Utils;
using System;
using System.Numerics;

namespace BasicArithmeticOperations.Utils.Calculator
{
    public class Calculator : ICalculator
    {
        public string Add(string firstNum, string secNum)
        {
            if (!Helper.IsNumericString(firstNum) || !Helper.IsNumericString(secNum)) // not numeric arguments
            {
                throw new ArgumentException(Messages.NumericArgumentOnly);
            }

            decimal a, b;
            BigInteger bigA, bigB;

            // if can parse to Decimal
            var isParseA = decimal.TryParse(firstNum, out a);
            var isParseB = decimal.TryParse(secNum, out b);

            if (isParseA && isParseB) // can parse arguments to decimal
            {
                try
                {
                    var result = a + b;
                    return result.ToString();
                } catch
                {
                    // do nothing, let compute in the bigInt
                }
            }
            else // if arguments are bigInt
            {
                var isParseBigA = BigInteger.TryParse(firstNum, out bigA);
                var isParseBigB = BigInteger.TryParse(secNum, out bigB);

                if (isParseBigA && isParseBigB)
                {
                    var bigResult = bigA + bigB;
                    return bigResult.ToString();
                }
            }

            return String.Empty;
        }

        public string Subtract(string minuend, string subtrahend)
        {
            if (!Helper.IsNumericString(minuend) || !Helper.IsNumericString(subtrahend)) // not numeric arguments
            {
                throw new ArgumentException(Messages.NumericArgumentOnly);
            }

            decimal a, b;
            BigInteger bigA, bigB;

            // if can parse to Decimal
            var isParseA = decimal.TryParse(minuend, out a);
            var isParseB = decimal.TryParse(subtrahend, out b);

            if (isParseA && isParseB) // can parse arguments to decimal
            {
                try
                {
                    var result = a - b;
                    return result.ToString();
                }
                catch
                {
                    // do nothing, let compute in the bigInt
                }
            }
            else // if arguments are bigInt
            {
                var isParseBigA = BigInteger.TryParse(minuend, out bigA);
                var isParseBigB = BigInteger.TryParse(subtrahend, out bigB);

                if (isParseBigA && isParseBigB)
                {
                    var bigResult = bigA - bigB;
                    return bigResult.ToString();
                }
            }

            return String.Empty;
        }

        public string Multiply(string firstNum, string secNum)
        {
            if (!Helper.IsNumericString(firstNum) || !Helper.IsNumericString(secNum)) // not numeric arguments
            {
                throw new ArgumentException(Messages.NumericArgumentOnly);
            }

            decimal a, b;
            BigInteger bigA, bigB;

            // if can parse to Decimal
            var isParseA = decimal.TryParse(firstNum, out a);
            var isParseB = decimal.TryParse(secNum, out b);

            if (isParseA && isParseB) // can parse arguments to decimal
            {
                try
                {
                    var result = a * b;
                    return result.ToString();
                }
                catch
                {
                    // do nothing, let compute in the bigInt
                }
            }
            else // if arguments are bigInt
            {
                var isParseBigA = BigInteger.TryParse(firstNum, out bigA);
                var isParseBigB = BigInteger.TryParse(secNum, out bigB);

                if (isParseBigA && isParseBigB)
                {
                    var bigResult = bigA * bigB;
                    return bigResult.ToString();
                }
            }

            return String.Empty;
        }

        public string Divide(string dividend, string divisor)
        {
            if (!Helper.IsNumericString(dividend) || !Helper.IsNumericString(divisor)) // not numeric arguments
            {
                throw new ArgumentException(Messages.NumericArgumentOnly);
            }

            decimal a, b;
            BigInteger bigA, bigB;

            // if can parse to Decimal
            var isParseA = decimal.TryParse(dividend, out a);
            var isParseB = decimal.TryParse(divisor, out b);

            if (isParseA && isParseB) // can parse arguments to decimal
            {
                if (b == 0)
                {
                    throw new ArgumentException(Messages.DivisionByZero);
                }

                try
                {
                    var result = a/b;
                    return result.ToString();
                }
                catch
                {
                    // do nothing, let compute in the bigInt
                }
            }
            else // if arguments are bigInt
            {
                var isParseBigA = BigInteger.TryParse(dividend, out bigA);
                var isParseBigB = BigInteger.TryParse(divisor, out bigB);

                if (isParseBigA && isParseBigB)
                {
                    var bigResult = bigA/bigB;
                    return bigResult.ToString();
                }
            }

            return String.Empty;
        }

    }
}

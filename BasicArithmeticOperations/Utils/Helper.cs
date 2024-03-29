﻿using System.Numerics;

namespace BasicArithmeticOperations.Utils
{
    public class Helper
    {
        public static bool IsOutOfBuiltInTypeRange(BigInteger number)
        {
            // check if big number is out of the built-in type range or not
            BigInteger a = (BigInteger)decimal.MinValue;
            BigInteger b = (BigInteger)decimal.MaxValue;

            if (number.CompareTo(a) < 0 || number.CompareTo(b) > 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsNumericString(string str)
        {
            if (str == null) 
            { 
                return false;
            }
    
            foreach (var s in str)
            {
                if (!char.IsDigit(s) && s != '.') return false;
            }

            return true;
        }
    }
}

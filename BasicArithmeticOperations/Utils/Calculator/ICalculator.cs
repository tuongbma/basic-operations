using System.Numerics;

namespace BasicArithmeticOperations.Utils.Calculator
{
    public interface ICalculator
    {
        public string Add(string firstNum, string secNum);
        public string Subtract(string minuend, string subtrahend);
        public string Multiply(string firstNum, string secNum);
        public string Divide(string dividend, string divisor);
    }
}

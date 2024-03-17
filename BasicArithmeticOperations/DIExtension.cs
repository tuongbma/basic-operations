using BasicArithmeticOperations.Utils.Calculator;
using System.Reflection.Metadata.Ecma335;

namespace BasicArithmeticOperations
{
    public static class DIExtension
    {

        public static IList<IServiceCollection> DIRegister(this IServiceCollection services)
        {
            IList<IServiceCollection> listDIRegister = new List<IServiceCollection>
            {
                services.AddTransient<ICalculator,Calculator>()
            };
            return listDIRegister;
        }
    }
}

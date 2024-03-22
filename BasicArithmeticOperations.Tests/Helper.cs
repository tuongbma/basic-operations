using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicArithmeticOperations.Tests
{
    internal class Helper
    {
        private static IServiceProvider Provider()
        {
            var service = new ServiceCollection();

            service.DIRegister();
            service.AddLogging();

            return service.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            var provider = Provider();
            return provider.GetService<T>() ?? throw new ArgumentNullException();
        }
    }
}

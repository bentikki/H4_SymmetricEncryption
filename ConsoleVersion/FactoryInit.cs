using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleVersion.Helpers;

namespace ConsoleVersion
{
    class FactoryInit
    {
        public static IBenchmarkTimer BenchmarkTimer
        {
            get
            {
                return new BenchmarkStopWatch();
            }
        }

        public static IKeyGenerator SecureKey
        {
            get
            {
                return new KeyGenerator();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMapper;

namespace LoadTests
{
    class Program
    {
        static void Main( string[] args )
        {
            PerformanceTest tests = new PerformanceTest();

            tests.Run();
        }
    }
}

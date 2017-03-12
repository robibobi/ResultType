using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcoc.ResultType
{
    class Program
    {
        static void Main(string[] args)
        {
            var x =
            from i in Foo(5)
            from j in FooError()
            from k in Foo(5)
            from l in FooDouble(3)
            select i + j + k + l;


        }


        private static Result<int> Foo(int i)
        {
            return new Success<int>(i);
        }

        private static Result<int> FooError()
        {
            return new Error<int>("ABC");
        }

        private static Result<double> FooDouble(double x)
        {
            return new Success<double>(x);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2._1
{
    internal class MyClass
    {
        public static Task<int> DivideAsync(int a, int b)
        {
            return Task.FromResult(a/b);
        }
    }
}

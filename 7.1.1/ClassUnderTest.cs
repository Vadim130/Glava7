using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1._1_2
{
    internal class ClassUnderTest
    {
        public async Task<bool> MyMethodAsync()
        {
            await Task.Delay(1);
            return false;
        }

    }
}

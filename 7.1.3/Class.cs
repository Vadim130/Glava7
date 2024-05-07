using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1._3
{
    interface IMyInterface
    {
        Task<int> SomethingAsync();
    }
    class SynchronousSuccess : IMyInterface
    {
        public Task<int> SomethingAsync()
        {
            return Task.FromResult(13);
        }
    }
    class SynchronousError : IMyInterface
    {
        public Task<int> SomethingAsync()
        {
            return Task.FromException<int>(new InvalidOperationException());
        }
    }
    class AsynchronousSuccess : IMyInterface
    {
        public async Task<int> SomethingAsync()
        {
            await Task.Yield(); // Принудительно включить асинхронное поведение.
            return 13;
        }
    }
}

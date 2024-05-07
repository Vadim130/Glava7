using System.Reactive.Linq;
namespace _7._5._2
{
    class MyAsyncer
    {
        /// <summary>
        /// Гарантирует, что асинхронный делегат выдает исключение.
        /// </summary>
        /// <typeparam name="TException">
        /// Тип ожидаемого исключения.
        /// </typeparam>
        /// <param name="action">Асинхронный делегат для тестирования.</param>
        /// <param name="allowDerivedTypes">
        /// Должны ли приниматься производные типы.
        /// </param>

        public static async Task<TException> ThrowsAsync<TException>(Func<Task> action, bool allowDerivedTypes = true)
         where TException : Exception
        {
            try
            {
                await action();
                var name = typeof(Exception).Name;
                Assert.Fail($"Delegate did not throw expected exception {name}.");
                return null;
            }
            catch (Exception ex)
            {
                if (allowDerivedTypes && !(ex is TException))
                    Assert.Fail($"Delegate threw exception of type {ex.GetType().Name}" + $", but {typeof(TException).Name} or a derived type was expected.");
                if (!allowDerivedTypes && ex.GetType() != typeof(TException))
                    Assert.Fail($"Delegate threw exception of type {ex.GetType().Name}" + $", but {typeof(TException).Name} was expected.");
                return (TException)ex;
            }
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task MyTimeoutClass_FailedGet_PropagatesFailure()
        {
            var stub = new FailureHttpServiceStub();
            var my = new MyTimeoutClass(stub);
            await MyAsyncer.ThrowsAsync<HttpRequestException>(async () =>
            {
                await my.GetStringWithTimeout("http://www.mail.ru/")
                .SingleAsync();
            });
        }
    }
}
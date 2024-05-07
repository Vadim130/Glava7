using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using Microsoft.Reactive.Testing;

namespace _7._6._1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MyTimeoutClass_SuccessfulGetShortDelay_ReturnsResult()
        {
            var scheduler = new TestScheduler();
            var stub = new SuccessHttpServiceStub
            {
                Scheduler = scheduler,
                Delay = TimeSpan.FromSeconds(0.5),
            };
            var my = new MyTimeoutClass(stub);
            string result = null;
            my.GetStringWithTimeout("http://www.mail.ru/", scheduler)
            .Subscribe(r => { result = r; });
            scheduler.Start();
            Assert.AreEqual("stub", result);
        }

        [Test]
        public void MyTimeoutClass_SuccessfulGetLongDelay_ThrowsTimeoutException()
        {
            var scheduler = new TestScheduler();
            var stub = new SuccessHttpServiceStub
            {
                Scheduler = scheduler,
                Delay = TimeSpan.FromSeconds(1.5),
            };
            var my = new MyTimeoutClass(stub);
            Exception result = null;
            my.GetStringWithTimeout("http://www.example.com/", scheduler)
            .Subscribe(_ => Assert.Fail("Received value"), ex => {
                result
            = ex;
            });
            scheduler.Start();
            Assert.That(result is TimeoutException);
        }
    }

}
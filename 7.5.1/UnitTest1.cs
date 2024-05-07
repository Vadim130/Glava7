using System.Reactive.Linq;

namespace _7._5._1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task MyTimeoutClass_SuccessfulGet_ReturnsResult()
        {
            var stub = new SuccessHttpServiceStub();
            var my = new MyTimeoutClass(stub);
            var result = await my.GetStringWithTimeout("http://www.mail.ru/")
            .SingleAsync();
            Assert.AreEqual("stub", result);
        }

    }
}
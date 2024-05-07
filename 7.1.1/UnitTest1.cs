using Nito.AsyncEx;

namespace _7._1._1_2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task MyMethodAsync_ReturnsFalse()
        {
            var objectUnderTest = new ClassUnderTest();
            bool result = await objectUnderTest.MyMethodAsync();
            Assert.IsFalse(result);
        }
        [Test]
        public void MyMethodAsync_ReturnsFalse2()
        {
            AsyncContext.Run(async () =>
            {
                var objectUnderTest = new ClassUnderTest();
                bool result = await objectUnderTest.MyMethodAsync();
                Assert.IsFalse(result);
            });
        }
    }
}
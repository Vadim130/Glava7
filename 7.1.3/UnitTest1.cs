namespace _7._1._3
{
    public class Tests
    {
        IMyInterface [] ifaces = new IMyInterface [3];
        [SetUp]
        public void Setup()
        {
            ifaces[0] = new SynchronousSuccess();
            ifaces[1] = new SynchronousError();
            ifaces[2] = new AsynchronousSuccess();
        }

        [Test]
        public async Task Test1()
        {
            int res = await ifaces[0].SomethingAsync();
            Assert.AreEqual(13, res);
        }

        [Test]
        public async Task Test2()
        {
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await ifaces[1].SomethingAsync());
            Assert.That(ex is InvalidOperationException );
        }

        [Test]
        public async Task Test3()
        {
            int res = await ifaces[2].SomethingAsync();
            Assert.AreEqual(13, res);
        }
    }
}
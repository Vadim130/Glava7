using System.Threading.Tasks.Dataflow;

namespace _7._4._1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task MyCustomBlock_AddsOneToDataItems()
        {
            var myCustomBlock = Task56.CreateMyCustomBlock();
            myCustomBlock.Post(3);
            myCustomBlock.Post(13);
            myCustomBlock.Complete();
            Assert.AreEqual(4, myCustomBlock.Receive());
            Assert.AreEqual(14, myCustomBlock.Receive());
            await myCustomBlock.Completion;
        }

        [Test]
        public async Task MyCustomBlock_Fault_DiscardsDataAndFaults()
        {
            var myCustomBlock = Task56.CreateMyCustomBlock();
            myCustomBlock.Post(3);
            myCustomBlock.Post(13);
            (myCustomBlock as IDataflowBlock).Fault(new
            InvalidOperationException());
            try
            {
                await myCustomBlock.Completion;
            }
            catch (AggregateException ex)
            {
                AssertExceptionIs<InvalidOperationException>(
                ex.Flatten().InnerException, false);
            }
        }
        public static void AssertExceptionIs<TException>(Exception ex,
 bool allowDerivedTypes = true)
        {
            if (allowDerivedTypes && !(ex is TException))
                Assert.Fail($"Exception is of type {ex.GetType().Name}, but " +
                $"{typeof(TException).Name} or a derived type was expected.");
            if (!allowDerivedTypes && ex.GetType() != typeof(TException))
                Assert.Fail($"Exception is of type {ex.GetType().Name}, but " +
                $"{typeof(TException).Name} was expected.");
        }

    }
}
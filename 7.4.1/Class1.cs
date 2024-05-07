using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace _7._4._1
{

    public class Task56
    {
        public static IPropagatorBlock<int, int> CreateMyCustomBlock()
        {
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
            var addBlock = new TransformBlock<int, int>(item => item + 2);
            var divideBlock = new TransformBlock<int, int>(item => item / 2);
            var flowCompletion = new DataflowLinkOptions { PropagateCompletion = true };
            multiplyBlock.LinkTo(addBlock, flowCompletion);
            addBlock.LinkTo(divideBlock, flowCompletion);
            return DataflowBlock.Encapsulate(multiplyBlock, divideBlock);
        }
        
    }

}

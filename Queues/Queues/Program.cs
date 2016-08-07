using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{

    class Program
    {
        static void Main(string[] args)
        {
            var limitedQue = new LimitedQueue<int>(5);
            Random itemGenerator = new Random();
            for (int i = 1; i <= 200; i++)
            {
                int item = itemGenerator.Next(0, 5);
             new Task(()=>limitedQue.Enque(item)).Start();
                if (i>6)
                {
                    int item2 = itemGenerator.Next(0, 5);
                    new Task(() => limitedQue.Deque(item2)).Start();
                }
            }
            Console.ReadLine();
        }
    }
}

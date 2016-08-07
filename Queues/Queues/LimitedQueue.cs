using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    internal class LimitedQueue<T>
    {
        public readonly List<T> _que = new List<T>();
        private readonly Semaphore semahpore;
        public LimitedQueue(int maxQue)
        {
            semahpore = new Semaphore(maxQue,maxQue);
        }

        public void Enque(T item)
        {
            Console.WriteLine("trying to enter number "+item);
            semahpore.WaitOne();
            _que.Add(item);
            Console.WriteLine("added "+item);
        }
        public void Deque(T item)
        {

                if (_que.Contains(item))
                {
                    Console.WriteLine("trying to remove " + item);
                    _que.Remove(item);
                    semahpore.Release();
                    Console.WriteLine("Removed " + item);
                }
            

        }

        public object Lk { get; set; }
    }
}

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            ParallelDemo pd= new ParallelDemo();
            //pd.ParallelInvokeMethod();
            //pd.ParallelForMethod();
            pd.ParallelStop();
            pd.ParallelBreak();
            Console.ReadLine();
        }
    }

    public class ParallelDemo
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();

        private static void Run1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 is cost 2 sec");
        }

        private static void Run2()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task 2 is cost 3 sec");
        }

        #region ParallelInvoke
        /// <summary>
        /// ParallelInvoke
        /// </summary>
        public void ParallelInvokeMethod()
        {
            _stopWatch.Start();
            Parallel.Invoke(Run1, Run2);
            _stopWatch.Stop();
            Console.WriteLine("Parallel run " + _stopWatch.ElapsedMilliseconds + " ms.");

            _stopWatch.Restart();
            Run1();
            Run2();
            _stopWatch.Stop();
            Console.WriteLine("Normal run " + _stopWatch.ElapsedMilliseconds + " ms.");
        }
        #endregion
        #region ParallelFor
        /// <summary>
        /// ParallelFor
        /// </summary>
        public void ParallelForMethod()
        {
            _stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 60000; j++)
                {
                    int sum = 0;
                    sum += i;
                }
            }
            _stopWatch.Stop();
            Console.WriteLine("NormalFor run " + _stopWatch.ElapsedMilliseconds + " ms.");

            _stopWatch.Reset();
            _stopWatch.Start();
            Parallel.For(0, 10000, item =>
            {
                for (int j = 0; j < 60000; j++)
                {
                    int sum = 0;
                    sum += item;
                }
            });
            _stopWatch.Stop();
            Console.WriteLine("ParallelFor run " + _stopWatch.ElapsedMilliseconds + " ms.");

        }
        #endregion
        #region stop
        /// <summary>
        /// stop
        /// </summary>
        public void ParallelStop()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            _stopWatch.Start();
            Parallel.For(0, 1000, (i, state) =>
            {
                if (bag.Count == 300)
                {
                    state.Stop();
                    return;
                }
                bag.Add(i);
            });
            _stopWatch.Stop();
            Console.WriteLine("Stop:Bag count is " + bag.Count + ", " + _stopWatch.ElapsedMilliseconds);
        }
        #endregion
        #region break
        /// <summary>
        /// break
        /// </summary>
        public void ParallelBreak()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            _stopWatch.Start();
            Parallel.For(0, 1000, (i, state) =>
            {
                if (bag.Count == 300)
                {
                    state.Break();
                    return;
                }
                bag.Add(i);
            });
            _stopWatch.Stop();
            Console.WriteLine("Break:Bag count is " + bag.Count + ", " + _stopWatch.ElapsedMilliseconds);
        }
        #endregion
    }
}

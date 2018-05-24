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
            #region 并行编程
            //ParallelDemo pd= new ParallelDemo();
            //pd.ParallelInvokeMethod();
            //pd.ParallelForMethod();
            //pd.ParallelStop();
            //pd.ParallelBreak();
            #endregion
            
            #region 异步编程
            Console.WriteLine("主线程准备调用异步方法");
            Task tDelay = AsyncDemo.Task1();
            Console.WriteLine("主线程调用异步方法完毕");
            //tDelay.Wait();//阻塞等待执行完毕
            //if (tDelay.IsCompleted)
            //    Console.WriteLine("延迟任务执行完毕");
            tDelay.ContinueWith(t => Console.WriteLine("延迟任务执行完毕，可以开启之后的任务"));

            #endregion
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 并行编程demo类
    /// </summary>
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
        /// ParallelInvoke：并行执行多个委托
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
    /// <summary>
    /// 异步编程demo类
    /// </summary>
    public class AsyncDemo
    {
        /// <summary>
        /// 延迟执行
        /// </summary>
        /// <returns></returns>
        public static async Task DelayResult()
        {
            Console.WriteLine("延迟任务等待执行");//属于主线程
            await Task.Delay(TimeSpan.FromSeconds(2));//此处直接返回不影响主线程执行
            Console.WriteLine("任务延迟2s开始执行");
        }
        /// <summary>
        /// 异步方法异常捕获
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Task1()
        {
            try
            {
                Console.WriteLine("try中task1线程id: " + Thread.CurrentThread.ManagedThreadId);
                
                var t1 = await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Task1正常执行，此时线程id：" + Thread.CurrentThread.ManagedThreadId);

                    return "task1 is ok";
                });
                int.Parse("aa");//引发异常，和task1隶属同一个线程
                return t1;
            }
            catch (Exception e)
            {
                Console.WriteLine("catch中线程id: " + Thread.CurrentThread.ManagedThreadId);//捕获异常，和引发异常处属于同一个线程
            }
            return "";       
        }
        /// <summary>
        /// 异步方法异常捕获
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Task2()
        {
            Console.WriteLine("try中task2线程id: " + Thread.CurrentThread.ManagedThreadId);
            var t2 = await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task2正常执行，此时线程id：" + Thread.CurrentThread.ManagedThreadId);
                return "task2 is ok";
            });
            return t2;
        }
    }
}

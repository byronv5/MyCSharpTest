using System;
using System.Threading;

namespace MutexSample
{
    //主要的两个排它锁构造是lock和Mutex（互斥体）。其中lock更快，使用也更方便。
    //而Mutex的优势是它可以跨进程的使用。
    class Program
    {
        // Create a new Mutex. The creating thread does not own the mutex.
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;//循环次数
        private const int numThreads = 3;//创建线程数量

        static void Main()
        {
            // Create the threads that will use the protected resource.
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
            Console.ReadLine();
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // 这个方法的资源只能被同步访问
        // so that only one thread at a time can enter.
        // 所有每次仅允许一个线程进入
        private static void UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.Name);
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                              Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.：在这里放置访问独占资源的代码

            // Simulate some work.：模拟一些任务
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the Mutex.
            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        }
    }
}

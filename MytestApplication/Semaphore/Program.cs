using System;
using System.Threading;

namespace SemaphoreSample
{
    /* System.Threading.Semaphore是表示一个Windows内核的信号量对象（操作系统级别，可以跨进程或AppDomain）。
     * Semaphore的WaitOne或者Release方法的调用大约会耗费1微秒的系统时间，而优化后的SemaphoreSlim则需要大致四分之一微秒。
     * 在计算中大量频繁使用它的时候SemaphoreSlim还是优势明显，
     * 加上SemaphoreSlim还丰富了不少接口，更加方便我们进行控制，所以在4.0以后的多线程开发中，推荐使用SemaphoreSlim
    */
    class Program
    {
        // A semaphore that simulates a limited resource pool.
        // 模拟受限制访问的资源池
        private static Semaphore _pool;

        // A padding interval to make the output more orderly.
        // 原子操作(Interlocked)资源数确保同步递增
        private static int _padding;

        public static void Main()
        {
            // Create a semaphore that can satisfy up to three
            // concurrent requests. Use an initial count of zero,
            // so that the entire semaphore count is initially
            // owned by the main program thread.
            // 创建可以允许同时有3个线程访问的信号量
            // 初始数0表示信号量初始全部可供主线程使用
            _pool = new Semaphore(0, 3);

            // Create and start five numbered threads. 
            // 启用5个线程
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));

                // Start the thread, passing the number.
                // i表示线程i
                t.Start(i);
            }

            // Wait for half a second, to allow all the
            // threads to start and to block on the semaphore.
            // 等待0.5s以让所有的线程阻塞
            Thread.Sleep(500);

            // The main thread starts out holding the entire
            // semaphore count. Calling Release(3) brings the 
            // semaphore count back to its maximum value, and
            // allows the waiting threads to enter the semaphore,
            // up to three at a time.
            // 主线程开始占有所有的信号量
            // 调用Release(3)释放全部信号量
            // 等待的线程此时既可以获取信号执行
            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(3);

            Console.WriteLine("Main thread exits.");
            Console.ReadLine();
        }

        private static void Worker(object num)
        {
            // Each worker thread begins by requesting the
            // semaphore.：获得信号的线程开始执行
            Console.WriteLine("Thread {0} begins " +
                "and waits for the semaphore.", num);
            _pool.WaitOne();//当线程试图对计数值已经为0的信号量执行WaitOne操作时，线程将阻塞直到计数值大于0

            // A padding interval to make the output more orderly.
            int padding = Interlocked.Add(ref _padding, 100);

            Console.WriteLine("Thread {0} enters the semaphore.", num);

            // The thread's "work" consists of sleeping for 
            // about a second. Each thread "works" a little 
            // longer, just to make the output more orderly.
            // 每个线程运行时间递增以保证输出有序
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}",
                num, _pool.Release());//Release()返回前一计数：也就是释放前的信号量是多少
        }
    }
}

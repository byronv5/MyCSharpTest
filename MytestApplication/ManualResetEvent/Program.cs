using System;
using System.Threading;

namespace ManualResetEventSample
{
    class Program
    {
        // mre is used to block and release threads manually. It is
        // created in the unsignaled state.
        // mre用以人工阻塞或者释放线程，false表示初始状态不发送信号（调用WaitOne即阻塞，如果为true则不阻塞）
        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
                              "\nto release all the threads.\n");
            Console.ReadLine();

            mre.Set();//释放信号：后边的线程调用WaitOne不会阻塞，除非调用Reset收回信号。这就是和AutoResetEvent最大的差别

            Thread.Sleep(500);
            Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
                              "\ndo not block. Press Enter to show this.\n");//线程3和4调用WaitOne不会阻塞
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
                              "\nwhen they call WaitOne().\n");//调用Reset方法回收信号，则之后的线程调用WaitOne会阻塞
            Console.ReadLine();

            mre.Reset();

            // Start a thread that waits on the ManualResetEvent.
            // Reset后线程5会在调用WaitOne后阻塞
            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Thread_5";
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
            Console.ReadLine();

            mre.Set();

            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }


        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls mre.WaitOne()");

            mre.WaitOne();

            Console.WriteLine(name + " ends.");
        }
    }
}

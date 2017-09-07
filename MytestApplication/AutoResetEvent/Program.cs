using System;
using System.Threading;

namespace AutoResetEventSample
{
    class Program
    {
        /// <summary>
        /// 事件发生时通知正在等待的线程
        /// </summary>
        private static AutoResetEvent event_1 = new AutoResetEvent(true);//初始有信号，可以理解为第一个到达的线程可以获得信号然后顺利执行
        private static AutoResetEvent event_2 = new AutoResetEvent(false);//初始无信号

        static void Main()
        {
            /*
             * 程序简介：
             * 1.按下enter后将创建3个线程并启动
             * 2.第一个线程获得event_1信号然后执行
             * 3.event_1进入无信号状态直到被set
             * 4.由于排他锁故其余线程遇到event_1挂起直到获得其信号
             * 5.第一个线程遇到event_2后挂起等待event_2被set
             * 6.event_1循环set 2 次让另外2个线程通过
             * 7.此时3个线程全部被event_2挂起
             * 8.event_2循环set 3 次让3个线程依次通过
             * 9.over
             */
            Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                              "The threads wait on AutoResetEvent #1, which was created\r\n" +
                              "in the signaled state, so the first thread is released.\r\n" +
                              "This puts AutoResetEvent #1 into the unsignaled state.");
            
            Console.ReadLine();

            for (int i = 1; i < 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }
            Thread.Sleep(250);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine();
                event_1.Set();//释放信号：和ManualResetEvent不同之处，AutoResetEvent会自动将信号置为不发送
                Thread.Sleep(250);
            }

            Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Press Enter to release a thread.");
                Console.ReadLine();
                event_2.Set();
                Thread.Sleep(250);
            }

            // Visual Studio: Uncomment the following line.
            //Console.Readline();
        }

        static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
            event_1.WaitOne();//第一个到达的线程将获得信号，其余线程等待set后才能获得信号
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

            Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
            event_2.WaitOne();//因为初始化的时候无信号，so所有的线程必须等待set后才能获得信号
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

            Console.WriteLine("{0} ends.", name);
        }
    }

}

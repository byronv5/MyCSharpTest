using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenSourceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task Cancel
            //CancellationTokenSource tokenSource = new CancellationTokenSource();
            //CancellationToken token = tokenSource.Token;
            //Console.WriteLine("任务开始执行...");
            //Task.Factory.StartNew(() =>
            //{               
            //    Console.WriteLine("取消任务...");
            //    Thread.Sleep(5000);
            //    Console.WriteLine("任务被取消，不应该输出...");
            //},token);
            ////Thread.Sleep(4000);//如果在任务执行期间取消任务不会中断
            //tokenSource.Cancel();//不保证100%取消
            #endregion
            #region Task CancelCallback
            var cts = new CancellationTokenSource(3000);//3s后IsCancellationRequested=true,并触发回调
            var ct = cts.Token;
            ct.Register(() => { Console.WriteLine("Task has been cancelled"); });//任务被Cancel后调用

            Task.Factory.StartNew(() =>
            {
                while (!ct.IsCancellationRequested)//意味着如果IsCancellationRequested=false则存在重复调用
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Task has finished");
                }
            }, ct);
            #endregion

            Console.ReadLine();
        }
    }
}

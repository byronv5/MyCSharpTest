using Quartz;
using System;
using System.Threading;

namespace QuartzSample
{
    [DisallowConcurrentExecution]//这个特性使得任务单线程运行，比如前一个任务计划还未执行完，后来的只能等
    public class HelloJob : IJob
    {
        /// <summary>
        /// 实现接口创建一个可执行job
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            //dosth：我们的计划任务
            Thread.Sleep(6000);//验证DisallowConcurrentExecution
            Console.WriteLine("Hello " + DateTime.Now.ToString());
        }
    }
}

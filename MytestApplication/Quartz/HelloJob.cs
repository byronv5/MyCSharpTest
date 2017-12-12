using Quartz;
using System;

namespace QuartzSample
{
    public class HelloJob : IJob
    {
        /// <summary>
        /// 实现接口创建一个可执行job
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            //dosth：我们的计划任务
            Console.WriteLine("Hello " + DateTime.Now.ToString());
        }
    }
}

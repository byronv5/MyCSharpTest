using Common.Logging;
using Quartz;
using Quartz.Impl;
using System;

namespace QuartzSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //监控日志
                LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = LogLevel.Info };

                //从配置中读取计划执行策略
                var factory = new StdSchedulerFactory(new System.Collections.Specialized.NameValueCollection()
                {
                     {"quartz.plugin.xml.fileNames","quartz_jobs.xml" },
                     {"quartz.plugin.xml.type","Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin,Quartz" }
                });
                IScheduler scheduler = factory.GetScheduler();
                scheduler.Start();

                Console.ReadLine();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
}

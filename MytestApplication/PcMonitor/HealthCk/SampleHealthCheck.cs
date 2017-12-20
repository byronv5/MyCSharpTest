using App.Metrics.Health;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PcMonitor.HealthCk
{
    /// <summary>
    /// 自定义健康检查
    /// </summary>
    public class SampleHealthCheck : HealthCheck
    {
        public SampleHealthCheck()
            : base("Sample Health Check") { }

        protected override ValueTask<HealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)//这是c#7.1语法
        {
            /* 
             * 仅仅用做示例，取得当前时间的秒数来触发
             * 实际项目中可以根据自己的需求来触发
             * 比如，当响应时间小于500ms返回健康，500-1000ms返回亚健康，大于1000ms返回不健康
             */
            if (DateTime.UtcNow.Second <= 20)
            {
                return new ValueTask<HealthCheckResult>(HealthCheckResult.Degraded());//亚健康
            }

            if (DateTime.UtcNow.Second >= 40)
            {
                return new ValueTask<HealthCheckResult>(HealthCheckResult.Unhealthy());//不健康
            }

            return new ValueTask<HealthCheckResult>(HealthCheckResult.Healthy());//健康
        }
    }
}

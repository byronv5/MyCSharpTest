using System;

namespace Adapter
{
    /// <summary>
    /// 目标角色
    /// </summary>
    class Target : ITarget
    {
        /// <summary>
        /// 实现目标接口
        /// </summary>
        public void Excute()
        {
            Console.WriteLine("正在执行目标计划");
        }
    }
}

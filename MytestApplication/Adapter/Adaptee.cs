using System;

namespace Adapter
{
    /// <summary>
    /// 源角色（被适配）
    /// </summary>
    class Adaptee
    {
        public void DoSomething()
        {
            Console.WriteLine("执行源角色计划");
        }
    }
}

using System;

namespace Command
{
    /// <summary>
    /// 需求组
    /// </summary>
    public class RequirementGroup : Igroup
    {
        public void Add()
        {
            Console.WriteLine("客户要增加需求。。。");
        }

        public void Change()
        {
            Console.WriteLine("客户要修改需求。。。");
        }

        public void Delete()
        {
            Console.WriteLine("客户要删除一个需求。。。");
        }

        public void Find()
        {
            Console.WriteLine("找到需求组。。。");
        }

        public void Plan()
        {
            Console.WriteLine("客户要提供需求方案。。。");
        }
    }
}

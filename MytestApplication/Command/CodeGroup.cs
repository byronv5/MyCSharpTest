using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    /// <summary>
    /// 开发组
    /// </summary>
    public class CodeGroup
    {
        public void Add()
        {
            Console.WriteLine("客户要增加功能。。。");
        }

        public void Change()
        {
            Console.WriteLine("客户要修改功能。。。");
        }

        public void Delete()
        {
            Console.WriteLine("客户要删除一个功能。。。");
        }

        public void Find()
        {
            Console.WriteLine("找到功能组。。。");
        }

        public void Plan()
        {
            Console.WriteLine("客户要提供功能方案。。。");
        }
    }
}

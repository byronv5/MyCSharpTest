using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    /// <summary>
    /// 美工组
    /// </summary>
    public class PageGroup
    {
        public void Add()
        {
            Console.WriteLine("客户要增加页面。。。");
        }

        public void Change()
        {
            Console.WriteLine("客户要修改页面。。。");
        }

        public void Delete()
        {
            Console.WriteLine("客户要删除一个页面。。。");
        }

        public void Find()
        {
            Console.WriteLine("找到页面组。。。");
        }

        public void Plan()
        {
            Console.WriteLine("客户要提供页面方案。。。");
        }
    }
}

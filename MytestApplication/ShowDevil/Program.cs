using DevilBase;
using System;
using THBiz;
using WMBussiness;

namespace ShowDevil
{
    class Program
    {
        static void Main(string[] args)
        {
            var thBizStock = new StockManage().AddStock(10);
            Console.WriteLine($"通过THBiz新增库存{thBizStock}");

            var wmsStock = new QueryStock().SelectStock();
            Console.WriteLine($"通过WMBussiness查询库存{wmsStock}");

            var nowStock = new Stock().GetStock();
            Console.WriteLine($"当前库存{nowStock}");

            Console.WriteLine("竟然没程序集未找到的错误！！！");
            Console.ReadLine();
        }
    }
}

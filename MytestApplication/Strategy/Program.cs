using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------策略模式----------");
            var add = new Add();//策略类暴漏出来了，可以使用工厂模式再次封装
            var context = new Context(add);
            var result = context.Excute(1, 2);
            Console.WriteLine($"计算结果：{result}");
            Console.ReadKey();
        }
    }
}

using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------模板方法模型-----------");
            var h1 = new HummerModelH1();
            h1.Run();
            Console.ReadKey();
        }
    }
}

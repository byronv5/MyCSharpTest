using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------适配器模式----------");
            ITarget target = new Target();
            target.Excute();

            ITarget targetee = new AdapterRole();
            targetee.Excute();
            Console.ReadKey();
        }
    }
}

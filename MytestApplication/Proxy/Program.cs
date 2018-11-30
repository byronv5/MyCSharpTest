using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------代理模式----------");
            var byron = new GamePlayer("Assassin");
            Console.WriteLine("角色交给代理");
            IGamePlayer proxy = new GamePlayerProxy(byron);
            Console.WriteLine($"开始代理{byron.PlayerName},开始时间{DateTime.Now}");
            proxy.Login("3672167","baibai");
            proxy.KillDevil();
            proxy.Upgade();
            Console.WriteLine($"代理结束,结束时间{DateTime.Now}");
            Console.ReadKey();
        }
    }
}

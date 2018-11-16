using Factory.HumanCreate;
using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 工厂模式
            Console.WriteLine("----------工厂模式---------");
            AbstractHumanFactory<IHuman> humanFactory = new HumanFactory<IHuman>();
            var chinese = humanFactory.CreateHuman("YellowMan");
            Console.WriteLine(chinese.GetColor());
            Console.WriteLine(chinese.Talk());

            var african = humanFactory.CreateHuman("BlackMan");
            Console.WriteLine(african.GetColor());
            Console.WriteLine(african.Talk());

            var american = humanFactory.CreateHuman("WhiteMan");
            Console.WriteLine(american.GetColor());
            Console.WriteLine(american.Talk());
            #endregion
            #region 简单工厂模式调用
            Console.WriteLine("----------简单工厂模式---------");
            chinese = SimpleHumanFactory<IHuman>.CreateHuman("YellowMan");
            Console.WriteLine(chinese.GetColor());
            Console.WriteLine(chinese.Talk());

            african = SimpleHumanFactory<IHuman>.CreateHuman("BlackMan");
            Console.WriteLine(african.GetColor());
            Console.WriteLine(african.Talk());

            american = SimpleHumanFactory<IHuman>.CreateHuman("WhiteMan");
            Console.WriteLine(american.GetColor());
            Console.WriteLine(american.Talk());
            #endregion
            Console.ReadKey();
        }
    }
}

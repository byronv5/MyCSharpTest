using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------抽象工厂-----------");
            var manFactory = new MaleFactory();
            Console.WriteLine("开始制造中国人...");
            var yellowMan = manFactory.CreateYellowHuman();
            Console.WriteLine("肤色：" + yellowMan.GetSkinColor());
            Console.WriteLine("语言：" + yellowMan.Talk());
            Console.WriteLine("性别：" + yellowMan.GetSex());

            Console.WriteLine("开始制造南非人...");
            var femaleFactory = new FemaleFactory();
            var blackWoman = femaleFactory.CreateBlackHuman();
            Console.WriteLine("肤色：" + blackWoman.GetSkinColor());
            Console.WriteLine("语言：" + blackWoman.Talk());
            Console.WriteLine("性别：" + blackWoman.GetSex());

            Console.ReadKey();
        }
    }
}

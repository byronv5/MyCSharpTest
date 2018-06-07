using System;

namespace Decorator
{
    class Program
    {
        /// <summary>
        /// 装饰者模式
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IDecoratorBase a = new ConcreteComponentA();
            a.ShowSkills();//a本身具有的功能

            IDecoratorBase b = new ConcreteComponentB();
            ConcreteDecrator decrator = new ConcreteDecrator(b);//装饰b：get到新技能
            decrator.ShowSkills();
            Console.ReadLine();
        }
    }
}

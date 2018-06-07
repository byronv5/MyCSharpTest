
using System;

namespace Decorator
{
    class ConcreteDecrator : DecoratorBase
    {
        public ConcreteDecrator(IDecoratorBase decorator) : base(decorator)
        {
        }
        public new void ShowSkills()
        {
            base.ShowSkills();
            //随意装饰
            Console.WriteLine("I'm also a warrior");
        }
    }
}

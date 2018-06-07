using System;

namespace Decorator
{
    class ConcreteComponentB : IDecoratorBase
    {
        public void ShowSkills()
        {
            Console.WriteLine("I'm a bussinessman!");
        }
    }
}

using System;

namespace Decorator
{
    class ConcreteComponentA : IDecoratorBase
    {
        public void ShowSkills()
        {
            Console.WriteLine("I'm assassin!");
        }
    }
}


namespace Decorator
{
    abstract class DecoratorBase : IDecoratorBase
    {
        protected IDecoratorBase decorator;
        public DecoratorBase(IDecoratorBase decorator)
        {
            this.decorator = decorator;
        }

        public void ShowSkills()
        {
            decorator.ShowSkills();
        }
    }
}

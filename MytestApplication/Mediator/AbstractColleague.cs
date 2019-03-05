namespace Mediator
{
    public abstract class AbstractColleague
    {
        protected AbstractMediator mediator;

        protected AbstractColleague(AbstractMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}

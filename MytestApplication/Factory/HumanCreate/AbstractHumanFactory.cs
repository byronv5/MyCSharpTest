namespace Factory.HumanCreate
{
    public abstract class AbstractHumanFactory<T> where T : IHuman
    {
        public abstract T CreateHuman(string who);
    }
}

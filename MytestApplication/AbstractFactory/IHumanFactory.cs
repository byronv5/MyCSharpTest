namespace AbstractFactory
{
    public interface IHumanFactory
    {
        IHuman CreateYellowHuman();
        IHuman CreateBlackHuman();
    }
}

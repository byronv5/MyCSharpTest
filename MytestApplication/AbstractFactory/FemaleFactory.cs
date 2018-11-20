namespace AbstractFactory
{
    public class FemaleFactory : IHumanFactory
    {
        public IHuman CreateBlackHuman()
        {
            return new FemaleBlackHuman();
        }

        public IHuman CreateYellowHuman()
        {
            return new FemaleYellowHuman();
        }
    }
}

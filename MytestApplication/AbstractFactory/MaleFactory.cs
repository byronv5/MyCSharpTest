namespace AbstractFactory
{
    public class MaleFactory : IHumanFactory
    {
        public IHuman CreateYellowHuman()
        {
            return new MaleYellowHuman();
        }

        public IHuman CreateBlackHuman()
        {
            return new MaleBlackHuman();
        }
    }
}

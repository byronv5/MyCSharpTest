namespace Strategy
{
    public class Add : ICaculator
    {
        public int Exec(int a, int b)
        {
            return a + b;
        }
    }
}

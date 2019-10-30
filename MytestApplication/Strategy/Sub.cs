namespace Strategy
{
    public class Sub : ICaculator
    {
        public int Exec(int a, int b)
        {
            return a - b;
        }
    }
}

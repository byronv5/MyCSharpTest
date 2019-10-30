namespace Strategy
{
    public class Context
    {
        private ICaculator cal;

        public Context(ICaculator _cal)
        {
            cal = _cal;
        }
        public int Excute(int a,int b)
        {
            return cal.Exec(a, b);
        }
    }
}

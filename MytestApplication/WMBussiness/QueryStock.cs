using DevilBase;

namespace WMBussiness
{
    public class QueryStock
    {
        public int SelectStock()
        {
            return new Stock().GetStock();
        }
    }
}

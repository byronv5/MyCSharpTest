using DevilBase;

namespace THBiz
{
    public class StockManage
    {
        public int AddStock(int num)
        {
            var nowStock = new Stock().GetStock();
            return nowStock + num;
        }
    }
}

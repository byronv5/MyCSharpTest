using System;

namespace Mediator
{
    /// <summary>
    /// 销售
    /// </summary>
    public class Sale : AbstractColleague
    {
        public Sale(AbstractMediator mediator) : base(mediator)
        {
        }
        /// <summary>
        /// 卖电脑
        /// </summary>
        /// <param name="num"></param>
        public void SellIBMComputer(int num)
        {
            //非自己的职责交给中介者
            Console.WriteLine($"售出IBM电脑{num}台");
        }
        /// <summary>
        /// 打折促销
        /// </summary>
        public void OffSale()
        {
            //非自己的职责交给中介者
            base.mediator.Excute("sale.offsell");
        }

        public int GetSaleStatus()
        {
            var rand = new Random();
            var saleStatus = rand.Next(100);
            Console.WriteLine($"IBM电脑销售情况：{saleStatus}");
            return saleStatus;
        }
    }
}

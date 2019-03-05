using System;

namespace Mediator
{
    public class Meditor : AbstractMediator
    {
        public override void Excute(string action, params object[] objs)
        {
            if (action.Equals("purchase.buy"))
            {
                //采购电脑
                this.BuyComputer((int)objs[0]);
            }
            else if (action.Equals("sale.sell"))
            {
                this.SellComputer((int)objs[0]);
            }
            else if (action.Equals("sale.offsell"))//打折处理
            {
                this.OffSell();
            }
            else if (action.Equals("stock.clear"))//清仓
            {
                this.ClearStock();
            }
        }

        /// <summary>
        /// 清仓
        /// </summary>
        private void ClearStock()
        {
            base.sale.OffSale();
            base.purchase.RefuseBuyIBM();
        }

        /// <summary>
        /// 打折处理
        /// </summary>
        private void OffSell()
        {
            Console.WriteLine($"当前IBM电脑库存{base.stock.GetStcokNum()}台，全部打折处理");
        }

        /// <summary>
        /// 卖电脑
        /// </summary>
        /// <param name="v"></param>
        private void SellComputer(int num)
        {
            if(base.stock.GetStcokNum() < num)
            {
                base.purchase.BuyIBMComputer(num);
            }
            base.stock.Increase(num);
        }

        /// <summary>
        /// 根据销售状态采购
        /// </summary>
        /// <param name="num"></param>
        private void BuyComputer(int num)
        {
            int saleStatus = base.sale.GetSaleStatus();
            if(saleStatus < 80)//卖得不好
            {
                num /= 2;//折半采购
            }
            
            base.stock.Increase(num);
        }

    }
}

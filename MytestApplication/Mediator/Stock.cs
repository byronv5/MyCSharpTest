using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// 库存
    /// </summary>
    public class Stock : AbstractColleague
    {
        public Stock(AbstractMediator mediator) : base(mediator)
        {
        }
        /// <summary>
        /// 初始库存
        /// </summary>
        public static int COMPUTER_NUMBER = 100;
        /// <summary>
        /// 新增库存
        /// </summary>
        /// <param name="num"></param>
        public void Increase(int num)
        {
            COMPUTER_NUMBER += num;
        }
        /// <summary>
        /// 扣减库存
        /// </summary>
        /// <param name="num"></param>
        public void Decrease(int num)
        {
            COMPUTER_NUMBER -= num;
        }
        /// <summary>
        /// 获取当前库存
        /// </summary>
        /// <returns></returns>
        public int GetStcokNum()
        {
            return COMPUTER_NUMBER;
        }

        /// <summary>
        /// 清理库存：采购停止采购、销售尽快销售
        /// </summary>
        public void ClearStock()
        {
            //非自己的职责交给中介者
            base.mediator.Excute("stock.clear");
        }
    }
}

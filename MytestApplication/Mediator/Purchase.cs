using System;

namespace Mediator
{
    /// <summary>
    /// 采购
    /// </summary>
    public class Purchase : AbstractColleague
    {
        public Purchase(AbstractMediator mediator) : base(mediator)
        {
        }
        /// <summary>
        /// 采购
        /// </summary>
        /// <param name="num"></param>
        public void BuyIBMComputer(int num)
        {
            //非自己的职责交给中介者
            base.mediator.Excute("purchase.buy", num);            
        }
        /// <summary>
        /// 拒绝采购（自己的职责）
        /// </summary>
        public void RefuseBuyIBM()
        {
            Console.WriteLine("通知采购停止采购IBM电脑");
        }
    }
}

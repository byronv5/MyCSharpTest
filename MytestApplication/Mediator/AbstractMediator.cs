namespace Mediator
{
    public abstract class AbstractMediator
    {
        protected Purchase purchase;
        protected Sale sale;
        protected Stock stock;

        protected AbstractMediator()
        {
            purchase = new Purchase(this);
            sale = new Sale(this);
            stock = new Stock(this);
        }
        /// <summary>
        /// 中介者统一调度方法
        /// </summary>
        /// <param name="action">操作</param>
        /// <param name="objs">参数可变</param>
        public abstract void Excute(string action, params object[] objs);
    }
}

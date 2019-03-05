using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------中介者模式-----------");
            AbstractMediator mediator = new Meditor();
            //采购电脑
            Console.WriteLine("采购人员开始采购电脑...");
            var purchase = new Purchase(mediator);
            purchase.BuyIBMComputer(100);
            //销售电脑
            Console.WriteLine("销售人员开始售卖电脑...");
            var sale = new Sale(mediator);
            sale.SellIBMComputer(1);
            //库存管理
            Console.WriteLine("库房管理人员开始清理库存...");
            var stock = new Stock(mediator);
            stock.ClearStock();

            Console.ReadLine();
        }
    }
}

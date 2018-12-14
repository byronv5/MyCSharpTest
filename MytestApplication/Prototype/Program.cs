using System;
using System.Threading;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------原型模式-----------");
            AdvTemplate advTemplate = new AdvTemplate();
            Mail mail = new Mail(advTemplate);
            mail.Receiver = "bxl";
            mail.Send();
            Thread.Sleep(2000);
            var cloneMail = (Mail)mail.Clone();//不走构造函数
            mail.Receiver = "hy";
            mail.Send();
            Console.Read();
        }
    }
}

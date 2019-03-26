using System;

namespace Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------职责链模式-----------");
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetOperator(h2);
            h2.SetOperator(h3);//设置职责链上的参与者，这里的代码可以再封装一层，因为客户端无须知道职责链上的每一个元素

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
            foreach (var request in requests)
            {
                h1.HandlerRequest(request);//职责链的首部来启动
            }
            Console.Read();
        }
    }
}

using System;

namespace Chain
{
    class ConcreteHandler3 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine($"{GetType().Name}处理请求{request}");
            }
            else if (nextOperator != null)
            {
                nextOperator.HandlerRequest(request);
            }
        }
    }
}

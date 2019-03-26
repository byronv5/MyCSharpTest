using System;

namespace Chain
{
    class ConcreteHandler1 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request > 0 && request < 10)
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

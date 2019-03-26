using System;

namespace Chain
{
    class ConcreteHandler2 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 10 && request < 20)
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

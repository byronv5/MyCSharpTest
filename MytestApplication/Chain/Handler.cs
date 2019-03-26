namespace Chain
{
    public abstract class Handler
    {
        protected Handler nextOperator;
        public void SetOperator(Handler handler)
        {
            this.nextOperator = handler;
        }
        /// <summary>
        /// 处理请求的方法
        /// </summary>
        /// <param name="request"></param>
        public abstract void HandlerRequest(int request);
    }
}

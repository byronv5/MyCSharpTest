namespace Command
{
    public class Invoker
    {
        //注入命令
        private AbstractCommand cmd;

        public Invoker(AbstractCommand cmd)
        {
            this.cmd = cmd;
        }
        /// <summary>
        /// 代理发送命令
        /// </summary>
        public void Action()
        {
            cmd.Exeute();
        } 
    }
}

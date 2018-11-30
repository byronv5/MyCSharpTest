namespace Proxy
{
    public interface IGamePlayer
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">账号</param>
        /// <param name="psd">密码</param>
        void Login(string name, string psd);
        /// <summary>
        /// 打怪
        /// </summary>
        void KillDevil();
        /// <summary>
        /// 升级
        /// </summary>
        void Upgade();
    }
}

using System;

namespace Proxy
{
    public class GamePlayer : IGamePlayer
    {
        /// <summary>
        /// 玩家昵称
        /// </summary>
        public string PlayerName { get; set; }
        public GamePlayer(string player)
        {
            PlayerName = player;
        }
        public void KillDevil()
        {
            Console.WriteLine($"玩家{PlayerName}在疯狂打怪...");
        }

        public void Login(string name, string psd)
        {
            Console.WriteLine($"账号{name}玩家{PlayerName}正在登录...");
        }

        public void Upgade()
        {
            Console.WriteLine($"恭喜玩家{PlayerName}升级！");
        }
    }
}

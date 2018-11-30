namespace Proxy
{
    public class GamePlayerProxy : IGamePlayer
    {
        private IGamePlayer gamePlayer { get; set; }
        public GamePlayerProxy(IGamePlayer gamePlayer)
        {
            this.gamePlayer = gamePlayer;
        }

        public void KillDevil()
        {
            gamePlayer.KillDevil();
        }

        public void Login(string name, string psd)
        {
            gamePlayer.Login(name, psd);
        }

        public void Upgade()
        {
            gamePlayer.Upgade();
        }
    }
}

namespace Singleton
{
    /// <summary>
    /// 饿汉模式
    /// </summary>
    public class HungrySingleton
    {
        private static readonly HungrySingleton instance = new HungrySingleton();
        private HungrySingleton() { }
        public static HungrySingleton GetInstance()
        {
            return instance;
        }
    }
}

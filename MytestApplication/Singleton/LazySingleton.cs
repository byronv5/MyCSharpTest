namespace Singleton
{
    /// <summary>
    /// 懒汉模式
    /// </summary>
    public class LazySingleton
    {
        private static LazySingleton instance;
        /// <summary>
        /// 锁：保证线程安全
        /// </summary>
        private static readonly object lockObj = new object();
        /// <summary>
        /// 私有构造防止继承、外部实例化
        /// </summary>
        private LazySingleton() { }
        public static LazySingleton GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new LazySingleton();
                    }
                }
            }
            return instance;
        }
    }
}

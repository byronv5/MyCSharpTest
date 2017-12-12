using System;
using CacheLibrary;
using ServiceStack.Redis;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CacheTest
{
    class Program
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public const string host = "r-bp138eac9d11ec94.redis.rds.aliyuncs.com";
        /// <summary>
        /// 密码
        /// </summary>
        public const string paswd = "u3k1A3uAuk";
        /// <summary>
        /// 端口
        /// </summary>
        public const int port = 6379;

        static void Main(string[] args)
        {
            try
            {
                Action[] actions = new Action[100000];
                for (int i = 0; i < actions.Length; i++)
                {
                    actions[i] = () => GetStr();
                }
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Parallel.Invoke(actions);
                watch.Stop();
                Console.WriteLine("执行时长(ms):" + watch.ElapsedMilliseconds);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("redis存取异常" + ex.Message);
            }
        }
        /*背景：db0中只有测试的10万数据*/
        #region 实体类型读写
        private static void InsertEntry()
        {
            using (RedisClient redisClient = new RedisClient(host, port, paswd))
            {
                var phoneFive = new Phone
                {
                    Id = 5,
                    Manufacturer = "Apple",
                    Model = "A1530",
                    Owner = new Person
                    {
                        Id = 0,
                        Age = 90,
                        Name = "Xiaolong",
                        Profession = "SportsMan",
                        Surname = "Bai"
                    }
                };
                var key = Guid.NewGuid().ToString();
                redisClient.Set(key, phoneFive);//十万条数据写入耗时39038毫秒
                Console.WriteLine("insert ok:" + key);
            }
        }
        private static void GetEntry()
        {
            using (RedisClient redisClient = new RedisClient(host, port, paswd))
            {              
                var key = "0000bb74-e0c5-42c6-86c8-73069acc4b0f";
                redisClient.Get<Phone>(key);//十万次读取耗时34696毫秒
                Console.WriteLine("query ok");
            }
        }
        #endregion
        /*背景：写入db0，读的是db2,里边混含生产数据约4万条，类型大小不一*/
        #region String读写
        private static void InsertStr()
        {
            using (RedisClient redisClient = new RedisClient(host, port, paswd))
            {               
                var key = Guid.NewGuid().ToString();
                redisClient.Set(key, 1);//十万条数据写入耗时31469毫秒
                Console.WriteLine("insert ok:" + key);
            }
        }
        private static void GetStr()
        {
            using (RedisClient redisClient = new RedisClient(host, port, paswd))
            {
                redisClient.Db = 2;
                var key = "100018";
                redisClient.Get(key);//十万次读取耗时41748毫秒
                Console.WriteLine("query ok");
            }
        }
        #endregion
    }
}

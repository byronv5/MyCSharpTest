using System;
using System.Collections.Generic;
using System.Configuration;
using Memcached.ClientLibrary;

namespace MemcacheApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取负载服务器集合
            string[] serverlist = SplitByComma(ConfigurationManager.AppSettings["MemCacheServers"]);
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.Initialize();

            MemcachedClient cache = new MemcachedClient();
            var getCache = cache.Get("TestCache");//获取cache
            if (getCache == null)
            {
                cache.Set("TestCache", "你好啊，memcache", DateTime.Now.AddHours(2));//获取不到则重新设置cache
                getCache = cache.Get("TestCache");
            }
            Console.WriteLine("获取到的cache为:" + getCache);
            cache.Delete("TestCache");//删除cache
            Console.Read();
        }

        /// <summary>
        /// 根据逗号将字符串拆分成数组
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        private static string[] SplitByComma(string strIn)
        {
            if (!string.IsNullOrEmpty(strIn))
            {
                return strIn.Split(',');
            }
            return null;
        }
    }
}

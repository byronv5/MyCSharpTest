using System;
using System.Globalization;
using System.Threading;
using CacheLibrary;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace CacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost";
            string elementKey = "bxl";

            using (RedisClient redisClient = new RedisClient(host))
            {
                #region string的存取
                IRedisTypedClient<Phone> phones = redisClient.As<Phone>();
                if (redisClient.Get<string>(elementKey) == null)
                {
                    // adding delay to see the difference
                    Thread.Sleep(5000);
                    redisClient.Set(elementKey, "hello world");
                    // save value in cache
                    Console.WriteLine("Redis String缓存已添加");
                }
                // get value from the cache by key
                var val = redisClient.Get<string>(elementKey);
                Console.WriteLine("获取到的Redis String缓存为" + val);
                #endregion
                #region 实体模型存取
                Phone phoneFive = phones.GetValue("5");
                if (phoneFive == null)
                {
                    // make a small delay
                    Thread.Sleep(5000);
                    // creating a new Phone entry
                    phoneFive = new Phone
                    {
                        Id = 5,
                        Manufacturer = "Apple",
                        Model = "A1530",
                        Owner = new Person
                        {
                            Id = 1,
                            Age = 90,
                            Name = "Xiaolong",
                            Profession = "SportsMan",
                            Surname = "Bai"
                        }
                    };
                    // adding Entry to the typed entity set
                    phones.SetEntry(phoneFive.Id.ToString(), phoneFive);
                }
                Console.WriteLine("获取到的Redis Phone缓存为" + phoneFive.Owner);
                Console.ReadLine();
                #endregion
            }
        }
    }
}

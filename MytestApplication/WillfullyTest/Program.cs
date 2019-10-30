using System;
using System.Threading;

/// <summary>
/// 随意测试
/// </summary>
namespace WillfullyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //List<UserModel> list = new List<UserModel>();
            //list.Add(new UserModel());
            //foreach (var item in list)
            //{
            //    Console.WriteLine($"{item}");//WillfullyTest.UserModel
            //}
            TimerCallback tc = new TimerCallback(_ => UserModel.DoSomeWork());
            var tm = new Timer(tc, null, 2000, Timeout.Infinite);//Timeout.Infinite the same as -1
            Console.ReadKey();
        }
    }
    public class UserModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static void DoSomeWork()
        {
            //Thread.Sleep(new Random().Next(2000, 5000));
            Console.WriteLine("回调成功");
        }
    }
}

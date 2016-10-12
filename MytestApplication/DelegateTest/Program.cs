using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DelegateTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            //创建匿名lamda委托
            c.SetDelegate((msg, result) => Console.WriteLine("Message:{0},Result:{1}", msg, result));
            //由Add方法通过Invoke触发
            c.Add(1, 23);
            
            Console.ReadLine();
        }
    }
}

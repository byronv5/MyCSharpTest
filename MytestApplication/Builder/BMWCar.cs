using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class BMWCar : CarModel
    {
        public override void Alarm()
        {
            Console.WriteLine("宝马鸣笛");
        }

        public override void EngineBoom()
        {
            Console.WriteLine("宝马发动");
        }

        public override void Start()
        {
            Console.WriteLine("宝马起步");
        }

        public override void Stop()
        {
            Console.WriteLine("宝马熄火");
        }
    }
}

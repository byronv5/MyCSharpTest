using System;

namespace Builder
{
    public class BenzCar : CarModel
    {
        public override void Alarm()
        {
            Console.WriteLine("奔驰鸣笛");
        }

        public override void EngineBoom()
        {
            Console.WriteLine("奔驰发动");
        }

        public override void Start()
        {
            Console.WriteLine("奔驰起步");
        }

        public override void Stop()
        {
            Console.WriteLine("奔驰熄火");
        }
    }
}

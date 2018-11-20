using System;

namespace TemplateMethod
{
    public class HummerModelH1 : HummerModel
    {
        public HummerModelH1()
        {
            isAlarm = false;
        }

        public override void Alarm()
        {
            Console.WriteLine("悍马H1鸣笛");
        }

        public override void EngineBoom()
        {
            Console.WriteLine("悍马H1发动");
        }

        public override void Start()
        {
            Console.WriteLine("悍马H1起步");
        }

        public override void Stop()
        {
            Console.WriteLine("悍马H1熄火");
        }
    }
}

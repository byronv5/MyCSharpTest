using System;
using System.Collections.Generic;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("汽车--建造者模式!");
            List<string> sequence = new List<string>();
            //定制奔驰汽车启动顺序
            sequence.Add("EngineBoom");
            sequence.Add("Alarm");
            sequence.Add("Start");
            sequence.Add("Stop");
            var benzBuilder = new BenzCarBuilder();
            benzBuilder.SetSequence(sequence);
            var benzCar = benzBuilder.BuildCar();
            benzCar.Run();
            Console.WriteLine("-----------------------------");
            //定制宝马汽车启动顺序
            sequence.Clear();
            sequence.Add("Start");
            sequence.Add("Alarm");
            sequence.Add("EngineBoom");           
            sequence.Add("Stop");
            var bmwBuilder = new BMWCarBuilder();
            bmwBuilder.SetSequence(sequence);
            var bmwCar = bmwBuilder.BuildCar();
            bmwCar.Run();

            //思考：启动顺序可以再包装一层？导演类
            Console.ReadKey();
        }
    }
}

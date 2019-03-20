using System;

namespace Command
{    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------命令模式：找代理人去布置命令，每个命令是一个类-----------");
            var addReq = new AddRequirementCommand();//客户增加需求
            var paoTui = new Invoker(addReq);
            paoTui.Action();//布置命令
            Console.ReadLine();
        }
    }
}

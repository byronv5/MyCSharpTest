using System;

namespace Prototype
{
    public class Mail : ICloneable
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Mail(AdvTemplate advTemplate)
        {
            Subject = advTemplate.GetAdvSubject();
            Body = advTemplate.GetAdvContext();
        }
        public void Send()
        {
            Console.WriteLine("开始发送邮件");
            Console.WriteLine($"接收人：{Receiver}");
            Console.WriteLine($"主题：{Subject}");
            Console.WriteLine($"内容：{Body}");
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

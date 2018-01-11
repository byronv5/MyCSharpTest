using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace NewTask
{
    class NewTask
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                //At this point we're sure that the task_queue queue won't be lost even if RabbitMQ restarts. Now we need to mark our messages as persistent - by setting IBasicProperties.SetPersistent to true.
                var properties = channel.CreateBasicProperties();
                //properties.SetPersistent(true);//翻译结果--此方法已经过时:“这种设置方法已经被摒弃，现在使用持久化属性取代它”
                properties.Persistent = true;//取代上面的写法
                //properties.DeliveryMode = 2;//也可以这么写

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        /// <summary>
        /// 生产消息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello.World!");
        }
    }
}

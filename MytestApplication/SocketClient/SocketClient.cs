using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace SocketClient
{
    static class SocketClient
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            //
            // TODO: 在此处添加代码以启动应用程序
            //
            byte[] data = new byte[1024];
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.Write("please input the server ip: ");//输入服务器ip
            string ipadd = Console.ReadLine();
            Console.WriteLine();
            Console.Write("please input the server port: ");//输入服务器端口
            int port = Convert.ToInt32(Console.ReadLine());
            if (ipadd != null)
            {
                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);//服务器的IP和端口
                try
                {
                    //因为客户端只是用来向特定的服务器发送信息，所以不需要绑定本机的IP和端口。不需要监听。
                    client.Connect(ie);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("unable to connect to server");
                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                    return;
                }
            }
            int recv = client.Receive(data);
            string stringdata = Encoding.UTF8.GetString(data, 0, recv);
            Console.WriteLine(stringdata);
            while (true)
            {//死循环维持和服务器的通话
                Console.Write(DateTime.Now + "客户端: ");
                string input = Console.ReadLine();
                if (input == "exit")//输入exit则断开连接
                    break;
                if (input != null) client.Send(Encoding.UTF8.GetBytes(input));
                data = new byte[1024];
                recv = client.Receive(data);
                stringdata = Encoding.UTF8.GetString(data, 0, recv);
                Console.WriteLine(DateTime.Now + "服务端：" + stringdata); //输出服务器的响应的消息
            }
            Console.WriteLine("disconnect from server");
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            Console.ReadLine();
        }
    }
}

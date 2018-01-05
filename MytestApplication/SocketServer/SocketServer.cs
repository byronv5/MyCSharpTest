using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    static class SocketServer
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
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);//本机预使用的IP和端口
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);//绑定
            newsock.Listen(10);//监听
            Console.WriteLine("waiting for a client...");
            Socket server = newsock.Accept();//阻塞等待客户端连接
            IPEndPoint clientip = (IPEndPoint)server.RemoteEndPoint;
            Console.WriteLine("connect with client :" + clientip.Address + " at port: " + clientip.Port);
            const string welcome = "Successfully connect,welcome here!";//客户端连接成功的提示信息
            byte[] data = Encoding.UTF8.GetBytes(welcome);
            server.Send(data, data.Length, SocketFlags.None);//发送信息
            while (true)
            {//用死循环来不断的从客户端获取信息
                data = new byte[1024];
                int recv = server.Receive(data);//用于表示客户端发送的信息长度
                string recvMsg = Encoding.UTF8.GetString(data, 0, recv);
                Console.WriteLine(DateTime.Now + "客户端：" + recvMsg);
                if (recv == 0) //当信息长度为0，说明客户端连接断开
                    break;
                Console.Write(DateTime.Now + "服务端: ");
                string input = Console.ReadLine();//服务端输入
                if (input != null) data = Encoding.UTF8.GetBytes(input);
                else//不输入则断开连接
                    break;
                server.Send(data, SocketFlags.None);
            }
            server.Close();
            newsock.Close();
            Console.WriteLine("Disconnected from " + clientip.Address);
            Console.ReadLine();
        }
    }
}

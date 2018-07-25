using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UdpOp
    {
        private Socket serverSocket;
        private byte[] dataStream = new byte[1024];
        public void Initialize()
        {
            var ip = GetLocalIPAddress();
            if (!string.IsNullOrWhiteSpace(ip))
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint server = new IPEndPoint(IPAddress.Parse(ip), 30000);
                serverSocket.Bind(server);
            }

        }
        public string GetLocalIPAddress()
        {
            string ipAddress = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                }
            }
            return ipAddress;
        }
        public void StartServer()
        {
            IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);
            EndPoint epSender = (EndPoint)clients;
          //  serverSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);
         
        }

        //void ReciveMsg()
        //{
        //    while (true)
        //    {
        //        EndPoint point = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的ip和端口号
        //        byte[] buffer = new byte[1024];
        //        int length = client.ReceiveFrom(buffer, ref point);//接收数据报
        //        string message = Encoding.UTF8.GetString(buffer, 0, length);
        //        Console.WriteLine(point.ToString() + message);
        //    }
        //}

        public void StartClent()
        {
            byte[] data = new byte[1024];
            string input, stringData;
            //构建TCP 服务器
            Console.WriteLine("这是客户端, 主机名是 {0}", Dns.GetHostName());
            //设置服务IP，设置TCP端口号
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.10.57"), 5555);
            //定义网络类型，数据连接类型和网络协议UDP
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string welcome = "你好服务器，我是客户端! ";
            data = Encoding.Unicode.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ip);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            byte[] sendData = new byte[1024];
            //对于不存在的IP地址，加入此行代码后，可以在指定时间内解除阻塞模式限制
            int recv = server.ReceiveFrom(sendData, ref Remote);
            Console.WriteLine("我是客户端，从服务器端： {0}接收到消息 ", Remote.ToString());
            Console.WriteLine(Encoding.Unicode.GetString(sendData, 0, recv));
            while (true)
            {
                input = Console.ReadLine();
                //退出
                if (input == "exit")
                    break;
                server.SendTo(Encoding.Unicode.GetBytes(input), Remote);
                byte[] recvData = new byte[1024];
                recv = server.ReceiveFrom(recvData, ref Remote);
                stringData = string.Format("服务器{0}发送：{1}", Remote.ToString(), Encoding.Unicode.GetString(recvData, 0, recv));
                Console.WriteLine(stringData);
            }
            Console.WriteLine("服务停止.");
            server.Close();
        }
    }
}

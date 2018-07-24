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
        public void StartServer()
        {
            int recv;
            byte[] revData = new byte[1024];
            byte[] sendData = new byte[1024];
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.10.57"), 5555);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ip);
            Console.WriteLine("我是服务端，主机名：{0}", Dns.GetHostName());
            Console.WriteLine("等待客户端连接.....");
            IPEndPoint sender = new IPEndPoint(IPAddress.Parse("192.168.10.57"), 0);
            EndPoint Remote = (EndPoint)(sender);
            recv = newsock.ReceiveFrom(revData, ref Remote);
            Console.WriteLine("我是服务端，客户端{0}连接成功", Remote.ToString());
            Console.WriteLine(Encoding.Unicode.GetString(revData, 0, recv));
            string welcome = "你好，我是服务器";
            sendData = Encoding.Unicode.GetBytes(welcome);
            newsock.SendTo(sendData, sendData.Length, SocketFlags.None, Remote);
            while (true)
            {
                sendData = new byte[1024];
                recv = newsock.ReceiveFrom(sendData, ref Remote);
                string recvData = string.Format("客户端{0}发送：{1}", Remote.ToString(), Encoding.Unicode.GetString(sendData, 0, recv));
                Console.WriteLine(recvData);
                // string recvData =string.Format("服务器接收到数据{0}", Encoding.ASCII.GetString(data, 0, recv));
                // byte.Parse(recvData);
                string recvDateSucceed = string.Format("服务器已收到.");
                sendData = Encoding.Unicode.GetBytes(recvDateSucceed);
                newsock.SendTo(sendData, sendData.Length, SocketFlags.None, Remote);
            }
        }

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

using System.Net;
using System.Net.Sockets;

namespace Server;

class Program
{
    static void Main(string[] args)
    {

        var clients = new HashSet<TcpClient>();
        var ip = IPAddress.Parse("127.0.0.1");
        var port = 27001;
        var tcpListener = new TcpListener(ip, port);
        tcpListener.Start(10);

        while (true)
        {
            Console.WriteLine($"{tcpListener.Server.LocalEndPoint} listening.....");
            var client = tcpListener.AcceptTcpClient();
            Console.WriteLine($"{client.Client.RemoteEndPoint} connected server....");
            clients.Add(client);

            Task.Run(() =>
            {
                var ClientS = client.GetStream();
                var binary = new BinaryReader(ClientS);
                var read = string.Empty;
                var UserIEP = string.Empty;
                var index = 0;

                while (true)
                {
                    read = binary.ReadString();
                    Console.WriteLine($"{ClientS.Socket.RemoteEndPoint} - {read}");
                    index = read.IndexOf(' ');
                    UserIEP = read.Substring(0, index);
                    var destination = clients.FirstOrDefault(x => x.Client.RemoteEndPoint?.ToString() == UserIEP);


                    var bw = new BinaryWriter(destination!.GetStream());

                    bw.Write($"{ClientS.Socket.RemoteEndPoint} - {read.Substring(index + 1)}");
                }

            });

        }
    }
}
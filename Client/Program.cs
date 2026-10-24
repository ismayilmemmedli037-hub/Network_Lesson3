using Client.Method;
using Client.Operations;

using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Command cmd = new Command();
            var client = new TcpClient("127.0.0.1", 27001);

            var serverStream = client.GetStream();

            var br = new BinaryReader(serverStream);
            var bw = new BinaryWriter(serverStream);

            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(br.ReadString());
                }
            });

            while (true)
            {
                int select = 0;
                bool isRun = true;
                List<string> options = new List<string> {
                    $"{Command.PROCLIST}",
                    $"{Command.RUN}",
                    $"{Command.KILL}" };

                while (isRun)
                {
                    Console.Clear();
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (select == i)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"-> {options[i]}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"   {options[i]}");
                        }
                    }
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        select--;
                        if (select < 0)
                        {
                            select = options.Count - 1;
                        }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        select++;
                        if (select >= options.Count)
                        {
                            select = 0;
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (select == 0)
                        {
                            Proclist.ShowProcesses();
                        }
                        else if (select == 1)
                        {
                            Run.RunMethod();
                        }
                        else if (select == options.Count - 1)
                        {
                            Kill.KillMethod();
                        }
                    }
                }
            }
        }
    }
}
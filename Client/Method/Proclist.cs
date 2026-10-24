using System.Diagnostics;

namespace Client.Method;

public static class Proclist
{
    public static void ShowProcesses()
    {
        Console.Clear();
        try
        {
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine();
                Console.WriteLine($"\u001b[33mId:\u001b[0m {process.Id}");
                Console.WriteLine($"\u001b[32mProcess Name:\u001b[0m {process.ProcessName}");
                Console.WriteLine($"\u001b[36mHandle Count:\u001b[0m {process.HandleCount}");
                Console.WriteLine($"\u001b[35mThreads Count:\u001b[0m {process.Threads.Count}");
                Console.WriteLine($"\u001b[94mMachine Name:\u001b[0m {process.MachineName}");
                Console.WriteLine();

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Occured: {ex.Message}");
        }

        Console.ReadKey();
    }
}

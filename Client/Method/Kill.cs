using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Method;

public static class Kill
{
    public static void KillMethod()
    {
        Console.Clear();
        Console.Write("Kill: ");
        var processes = Process.GetProcessesByName(Console.ReadLine());

        try
        {
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
            Console.WriteLine($"\n\u001b[31mSuccesfully Completed\u001b[0m");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n\u001b[31mThe process couldn't stop: \u001b[0m{ex.Message}");
            Console.ReadKey();
        }
    }
}
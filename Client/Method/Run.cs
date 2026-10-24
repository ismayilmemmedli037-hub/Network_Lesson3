using System.Diagnostics;
namespace Client.Operations;

public static class Run
{
    public static void RunMethod()
    {
        Console.Clear();
        try
        {
            string nameOfProcess = string.Empty;
            Console.Write("System name: ");
            nameOfProcess = Console.ReadLine();
            Process.Start(nameOfProcess);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Occured: {ex.Message}");
        }
    }
}

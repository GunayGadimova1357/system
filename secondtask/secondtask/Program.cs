using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        Process process = new Process();
        process.StartInfo.FileName = "/Users/xalida/RiderProjects/secondtask/ChildApp/bin/Debug/net8.0/ChildApp";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        
        try
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine("Ждать завершения (1) или завершить принудительно (2)?");
            string input = Console.ReadLine();

            if (input == "1")
            {
                process.WaitForExit();
                Console.WriteLine($"exit code: {process.ExitCode}");
            }
            else if (input == "2")
            {
                process.Kill();
                Console.WriteLine("Процесс завершён принудительно.");
            }
            Console.WriteLine($"exit code: {process.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }

 
    }
}

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        var process = new Process();
        process.StartInfo.FileName = "/Users/xalida/RiderProjects/firsttask/ChildApp/bin/Debug/net8.0/ChildApp";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        try
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine($"output: {output}");
            Console.WriteLine($"exit code: {process.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }
    }
}
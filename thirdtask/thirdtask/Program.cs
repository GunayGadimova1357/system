using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("first num: ");
            string firstNum = Console.ReadLine();
            Console.WriteLine("second num: ");
            string secondNum = Console.ReadLine();
            Console.WriteLine("op(+;-;*;/: ");
            string op = Console.ReadLine();
            string args = $"{firstNum} {secondNum} {op}";
            Process process = new Process();
            process.StartInfo.FileName = "/Users/xalida/RiderProjects/thirdtask/ChildApp/bin/Debug/net8.0/ChildApp";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine($"result: {result}");
            Console.WriteLine($"exit code: {process.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }

 
    }
}
using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            /// bicycle is fast. I have a bicycle. My friend has a bicycle too.
            /// bicycle 
            Console.WriteLine("file path: ");
            string filePath = Console.ReadLine();
            
            Console.WriteLine("word to find: ");
            string word = Console.ReadLine();
            
            string args = $"{filePath} {word}";
            
            Process process = new Process();
            process.StartInfo.FileName = "/Users/xalida/RiderProjects/fourthtask/ChildApp/bin/Debug/net8.0/ChildApp";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine($"result: {result.Trim()} times");
            Console.WriteLine($"exit code: {process.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }

 
    }
}
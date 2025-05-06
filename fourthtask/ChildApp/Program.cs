using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Недостаточно аргументов.");
            Environment.Exit(1);
            return;
        }

        string path = args[0];
        string word = args[1];

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден.");
            Environment.Exit(2);
            return;
        }

        string content = File.ReadAllText(path);
        int count = content.Split(new[] { word }, StringSplitOptions.None).Length - 1;

        Console.WriteLine(count);
        Environment.Exit(0);
    }
}
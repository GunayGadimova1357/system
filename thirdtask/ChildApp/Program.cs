using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("not enough arguments.");
            Environment.Exit(1);
            return;
        }

        int a = int.Parse(args[0]);
        int b = int.Parse(args[1]);
        string op = args[2];

        int result = 0;

        switch (op)
        {
            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/": result = b != 0 ? a / b : 0; break;
            default:
                Console.WriteLine("unknown operator.");
                Environment.Exit(2);
                return;
        }

        Console.WriteLine(result);
        Environment.Exit(0);
    }
}
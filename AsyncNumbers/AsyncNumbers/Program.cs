

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AsyncNumbers.Services; 

namespace AsyncNumbers
{
    class Program
    {
        static async Task Main()
        {
            var rnd = new Random();
            
            List<int> numbers = Enumerable.Range(0, 20)
                .Select(_ => rnd.Next(1, 101))
                .ToList();

            Console.WriteLine("initial numbers:");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine();
            
            var sw = Stopwatch.StartNew();

            Task<List<int>> evensTask = NumberProcessor.FilterEvensAsync(numbers);
            Task<List<int>> oddsTask  = NumberProcessor.FilterOddsAsync(numbers);
            Task<int> sumTask         = NumberProcessor.CalculateSumAsync(numbers);
            
            await Task.WhenAll(evensTask, oddsTask, sumTask);
            
            List<int> evens = await evensTask;
            List<int> odds  = await oddsTask;
            int sum         = await sumTask;

            sw.Stop();
            
            Console.WriteLine($"even numbers:   {string.Join(", ", evens)}");
            Console.WriteLine($"odd numbers: {string.Join(", ", odds)}");
            Console.WriteLine($"sum of numbers: {sum}");
            Console.WriteLine();
            Console.WriteLine($"execution time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
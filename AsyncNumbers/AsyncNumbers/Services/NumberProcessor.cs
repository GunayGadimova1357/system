using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncNumbers.Services
{
    public static class NumberProcessor
    {
        public static async Task<List<int>> FilterEvensAsync(List<int> numbers)
        {
            await Task.Delay(1500); 
            return numbers.Where(n => n % 2 == 0).ToList();
        }

        public static async Task<List<int>> FilterOddsAsync(List<int> numbers)
        {
            await Task.Delay(1500); 
            return numbers.Where(n => n % 2 != 0).ToList();
        }

        public static async Task<int> CalculateSumAsync(List<int> numbers)
        {
            await Task.Delay(1000); 
            return numbers.Sum();
        }
    }
}
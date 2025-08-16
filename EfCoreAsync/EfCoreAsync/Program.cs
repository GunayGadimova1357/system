using System.Threading.Tasks;
using EfCoreAsync.Services;
using EfCoreAsync.Data;

class Program
{
    static async Task Main()
    {
        // using (var ctx = new AppDbContext())
        // {
        //     ctx.Database.EnsureDeleted();            
        //     await ctx.Database.EnsureCreatedAsync(); 
        // }
        
        StudentService.AddStudentManually("Alice (manual)");
        StudentService.AddStudentManually("Bob (manual)");
        StudentService.ShowAllStudentsManually();
        Console.WriteLine();
        await StudentService.AddStudentAsync("Carol (async)");
        await StudentService.AddStudentAsync("Dave (async)");
        await StudentService.ShowAllStudentsAsync();
    }
}
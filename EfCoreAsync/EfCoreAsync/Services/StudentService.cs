using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreAsync.Data;
using EfCoreAsync.Entities;

namespace EfCoreAsync.Services;

public static class StudentService
{
    static void Log(string msg) =>
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] [T{Thread.CurrentThread.ManagedThreadId}] {msg}");

    public static void AddStudentManually(string name)
    {
        // Log("AddStudentManually(): start");
        var ok = Task.Run(() =>
        {
            // Log("AddStudentManually(): inside Task.Run");
            using var ctx = new AppDbContext();
            ctx.Database.EnsureCreated();

            var normalized = name.Trim();
            
            var exists = ctx.Students.Any(st => st.Name == normalized);
            if (exists)
            {
                // Log($"[MANUALLY] Student with name `{normalized}` already exists.]");
                return false;
            }
            
            ctx.Students.Add(new Student { Name = name });
            ctx.SaveChanges();              
            return true;
        }).GetAwaiter().GetResult();        
        // Log($"AddStudentManually(): done, result={ok}");
    }

    public static void ShowAllStudentsManually()
    {
        // Log("ShowAllStudentsManually(): start");
        var items = Task.Run(() =>
        {
            // Log("ShowAllStudentsManually(): inside Task.Run");
            using var ctx = new AppDbContext();
            ctx.Database.EnsureCreated();
            return ctx.Students
                      .OrderBy(s => s.Id)
                      .Select(s => new { s.Id, s.Name })
                      .ToList();            
        }).GetAwaiter().GetResult();

        foreach (var s in items) Log($"[MANUAL] {s.Id}: {s.Name}");
        // Log("ShowAllStudentsManually(): done");
    }
    

    public static async Task AddStudentAsync(string name)
    {
        // Log("AddStudentAsync(): start");
        using var ctx = new AppDbContext();
        await ctx.Database.EnsureCreatedAsync();
        
        var normalized = name.Trim();
        if (await ctx.Students.AnyAsync(st => st.Name == normalized))
        {
            // Log($"[ASYNC] {normalized} already exists.");
            return;
        }
        await ctx.Students.AddAsync(new Student { Name = name });
        await ctx.SaveChangesAsync();
        // Log("AddStudentAsync(): done");
    }

    public static async Task ShowAllStudentsAsync()
    {
        // Log("ShowAllStudentsAsync(): start");
        using var ctx = new AppDbContext();
        await ctx.Database.EnsureCreatedAsync();
        var items = await ctx.Students
                             .OrderBy(s => s.Id)
                             .Select(s => new { s.Id, s.Name })
                             .ToListAsync(); 
        foreach (var s in items) Log($"[ASYNC]  {s.Id}: {s.Name}");
        // Log("ShowAllStudentsAsync(): done");
    }
}
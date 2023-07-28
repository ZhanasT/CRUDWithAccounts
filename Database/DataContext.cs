using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Database.Entity;

namespace Database;

public class DataContext : DbContext
{
    private string connectionString = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName,
    @"Database\sqlite.db");
    public DataContext()
    {

    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
        Database.EnsureCreated();
    
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={connectionString}");
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Disk> Disks => Set<Disk>();
    public DbSet<SelectedDisk> SelectedDisks => Set<SelectedDisk>();
}

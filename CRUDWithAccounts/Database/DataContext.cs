using Microsoft.EntityFrameworkCore;
using CRUDWithAccounts.Database.Entity;

namespace CRUDWithAccounts.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Disk> Disks => Set<Disk>();
}

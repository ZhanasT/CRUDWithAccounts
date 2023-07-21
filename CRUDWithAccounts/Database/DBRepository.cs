using Microsoft.EntityFrameworkCore;
using CRUDWithAccounts.Database.Entity;

namespace CRUDWithAccounts.Database;

public class DBRepository : IDBRepository
{
    private DataContext db;
    public DBRepository(DataContext _db)
    {
        db = _db;
    }
    public async Task<List<Disk>> GetAllDisks()
    {
        return await db.Disks.ToListAsync();
    }
    public async Task<List<Disk>> GetDisksByManufacturer(string manufacturer)
    {
        return await db.Disks.Where(disk => disk.Manufacturer == manufacturer).ToListAsync();
    }
    public async Task<List<Disk>> GetDisksByType(string type)
    {
        return await db.Disks.Where(disk => disk.Type == type).ToListAsync();
    }
}

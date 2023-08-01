using Microsoft.EntityFrameworkCore;
using Database.Entity;

namespace Database;

public class DBRepository : IDBRepository
{
    private DataContext db;
    public DBRepository(DataContext _db)
    {
        db = _db;
    }
    public async Task<List<Disk>> GetAllDisksAsync()
    {
        return await db.Disks.ToListAsync();
    }
    public async Task<List<Disk>> GetDisksByManufacturerAsync(string manufacturer)
    {
        return await db.Disks.Where(disk => disk.Manufacturer == manufacturer).ToListAsync();
    }
    public async Task<List<Disk>> GetDisksByTypeAsync(string type)
    {
        return await db.Disks.Where(disk => disk.Type == type).ToListAsync();
    }
    public async Task<Account?> FindAccountAsync(string username, string password)
    {
        return await db.Accounts.FirstOrDefaultAsync(account => account.Login == username & account.Password == password);
    }
        
    public async Task AddAccountAsync(Account account)
    {
        await db.Accounts.AddAsync(account);
        await db.SaveChangesAsync();
    }
    public async Task<List<Disk>> GetShoppingCartAsync(string username)
    {
        return await db.SelectedDisks.Include(sd => sd.disk).Where(sd => sd.account.Login == username).Select(sd => sd.disk).ToListAsync();
    }
    public async Task AddToShoppingCartAsync(int diskId, string username)
    {
        var diskToAdd = await db.Disks.Where(disk => disk.Id == diskId).FirstOrDefaultAsync();
        var accountToAdd = await db.Accounts.Where(account => account.Login == username).FirstOrDefaultAsync();
        if (diskToAdd is null || accountToAdd is null)
        {
            throw new Exception("Disk or Account not found");
        }
        var selectedDisk = new SelectedDisk()
        {
            account = accountToAdd,
            disk = diskToAdd
        };
        await db.SelectedDisks.AddAsync(selectedDisk);
        await db.SaveChangesAsync();
    }
    public async Task DeleteFromShoppingCartAsync(string username, int diskId)
    {
        var selectedDiskToRemove = await db.SelectedDisks
            .Include(sd => sd.disk)
            .Include(sd => sd.account)
            .Where(sd => sd.disk.Id == diskId && sd.account.Login == username).FirstOrDefaultAsync();
        db.SelectedDisks.Remove(selectedDiskToRemove);
        await db.SaveChangesAsync();
    }
    public async Task AddDiskAsync(Disk diskToAdd)
    {
        await db.Disks.AddAsync(diskToAdd);
        await db.SaveChangesAsync();
    }
    public async Task DeleteDiskAsync(int diskId)
    {
        var diskToDelete = await db.Disks.Where(disk => disk.Id == diskId).FirstOrDefaultAsync();
        db.Disks.Remove(diskToDelete);
        await db.SaveChangesAsync();
    }
}

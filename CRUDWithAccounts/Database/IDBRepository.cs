using CRUDWithAccounts.Database.Entity;

namespace CRUDWithAccounts.Database;

public interface IDBRepository
{
    public Task<List<Disk>> GetAllDisks();
    public Task<List<Disk>>GetDisksByManufacturer(string manufacturer);
    public Task<List<Disk>> GetDisksByType(string type);
    public Task<Account?> FindAccount(string username, string password);
    public Task AddAccount(Account account);

}

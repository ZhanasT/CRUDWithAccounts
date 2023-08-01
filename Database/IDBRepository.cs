using Database.Entity;

namespace Database;

public interface IDBRepository
{
    public Task<List<Disk>> GetAllDisksAsync();
    public Task<List<Disk>>GetDisksByManufacturerAsync(string manufacturer);
    public Task<List<Disk>> GetDisksByTypeAsync(string type);
    public Task<Account?> FindAccountAsync(string username, string password);
    public Task AddAccountAsync(Account account);
    public Task<List<Disk>> GetShoppingCartAsync(string username);
    public Task AddToShoppingCartAsync(int diskId, string username);
    public Task DeleteFromShoppingCartAsync(string username, int diskId);
    public Task AddDiskAsync(Disk diskToAdd);
    public Task DeleteDiskAsync(int diskId);
}

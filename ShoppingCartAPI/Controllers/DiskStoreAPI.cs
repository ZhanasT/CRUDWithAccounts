using Microsoft.AspNetCore.Mvc;
using Database.Entity;
using Database;

namespace ShoppingCartAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiskStoreAPI : ControllerBase
{
    private IDBRepository repository;
    public DiskStoreAPI(IDBRepository _repository)
    {
        repository = _repository;
    }
    [HttpPost]
    public async Task<IActionResult> AddDisk(Disk diskToAdd)
    {
        await repository.AddDiskAsync(diskToAdd);
        return Ok();
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteDisk(int diskId)
    {
        await repository.DeleteDiskAsync(diskId);
        return Ok();
    }
}

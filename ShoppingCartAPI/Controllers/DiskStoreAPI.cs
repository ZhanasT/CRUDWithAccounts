using Microsoft.AspNetCore.Mvc;
using Database.Entity;
using Database;

namespace ShoppingCartAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DiskStoreAPI : ControllerBase
{
    private IDBRepository repository;
    public DiskStoreAPI(IDBRepository _repository)
    {
        repository = _repository;
    }
    [HttpDelete("{diskId}")]
    public async Task<IActionResult> DeleteDisk(int diskId)
    {
        await repository.DeleteDiskAsync(diskId);
        return Ok();
    }
}

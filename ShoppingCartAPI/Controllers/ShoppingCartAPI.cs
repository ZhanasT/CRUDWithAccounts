using Microsoft.AspNetCore.Mvc;
using Database;

namespace ShoppingCartAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ShoppingCartAPI : ControllerBase
{
    private IDBRepository repository;
    public ShoppingCartAPI(IDBRepository _repository)
    {
        repository = _repository;
    }
    [HttpPost("{diskId}/{username}")]
    public async Task<IActionResult> AddToShoppingCart(int diskId, string username)
    {
        await repository.AddToShoppingCartAsync(diskId, username);
        return Ok();
    }
    [HttpGet("{username}")]
    public async Task<IActionResult> GetShoppingCart(string username)
    {
        var disks = await repository.GetShoppingCartAsync(username);
        return Ok(disks);
    }
    [HttpDelete("{username}/{diskId}")]
    public async Task<IActionResult> DeleteFromShoppingCart(string username, int diskId)
    {
        await repository.DeleteFromShoppingCartAsync(username, diskId);
        return Ok();
    }
}

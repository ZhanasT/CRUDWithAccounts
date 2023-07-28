using Microsoft.AspNetCore.Mvc;
using Database;

namespace ShoppingCartAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartAPI : ControllerBase
{
    private IDBRepository repository;
    public ShoppingCartAPI(IDBRepository _repository)
    {
        repository = _repository;
    }
    [HttpGet]
    public async Task<IActionResult> AddToShoppingCart(int diskId, string username)
    {
        await repository.AddToShoppingCartAsync(diskId, username);
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CRUDWithAccounts.ViewModels;
using Database.Entity;
using Database;

namespace CRUDWithAccounts.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IDBRepository repository;

    public AdminController(ILogger<AdminController> logger, IDBRepository _repository)
    {
        _logger = logger;
        repository = _repository;
    }
  
    public IActionResult AdminPage()
    {
        var userViewModel = new UserWithRoleViewModel();
        userViewModel.Username = User.Identity.Name;
        var claims = ((ClaimsIdentity)User.Identity).Claims;
        string role = claims.Where(claim => claim.Type.Split('/').LastOrDefault() == "role").FirstOrDefault().Value;
        userViewModel.Role = role;
        return View(userViewModel);
    }
    public IActionResult AddDisk()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddDisk(DiskViewModel diskViewModel)
    {
        Disk diskToAdd = new Disk() {
            Manufacturer = diskViewModel.Manufacturer,
            Model = diskViewModel.Manufacturer,
            Type = diskViewModel.Type,
            Capacity = diskViewModel.Capacity,
            ReadSpeed = diskViewModel.ReadSpeed,
            WriteSpeed = diskViewModel.WriteSpeed,
            Cost = diskViewModel.ReadSpeed
        };
        await repository.AddDiskAsync(diskToAdd);
        return RedirectToAction("AddDiskPage");
    }
}

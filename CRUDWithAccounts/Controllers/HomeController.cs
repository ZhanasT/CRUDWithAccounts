using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CRUDWithAccounts.Models;
using Database;
using Microsoft.AspNetCore.Authorization;

namespace CRUDWithAccounts.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDBRepository repository;

    public HomeController(ILogger<HomeController> logger, IDBRepository _repository)
    {
        _logger = logger;
        repository = _repository;
    }

    public IActionResult Index(string? username)
    {
        return View(username);
    }


    public async Task<IActionResult> Catalog()
    {
        var list = await repository.GetAllDisksAsync();
        if (User.Identity.IsAuthenticated)
        {
            ViewData["Usename"] = User.Identity.Name;
            var claims = ((ClaimsIdentity)User.Identity).Claims;
            string role = claims.Where(claim => claim.Type.Split('/').LastOrDefault() == "role").FirstOrDefault().Value;
            ViewData["Role"] = role;
        }

        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDWithAccounts.Models;
using CRUDWithAccounts.Database;
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
        return View(await repository.GetAllDisks());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

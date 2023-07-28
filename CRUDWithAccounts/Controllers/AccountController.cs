using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entity;
using Database.Enum;
using CRUDWithAccounts.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using CRUDWithAccounts.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace CRUDWithAccounts.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IDBRepository repository;

    public AccountController(ILogger<AccountController> logger, IDBRepository _repository)
    {
        _logger = logger;
        repository = _repository;
    }
  
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var foundAccount = await repository.FindAccountAsync(model.Username, HashPasswordHelper.HashPassword(model.Password));

        if (foundAccount is not null)
        {
            if (foundAccount.Login == model.Username && foundAccount.Password == HashPasswordHelper.HashPassword(model.Password))
            {
                return await customLogin(model.Username, foundAccount.Role);
            }
            else
            {
                return View();
            }
        }
        else
        {
            var accountToAdd = new Account() {
                Login = model.Username,
                Password = HashPasswordHelper.HashPassword(model.Password),
                Role = Database.Enum.Role.User
            };
            await repository.AddAccountAsync(accountToAdd);
            return await customLogin(model.Username, Role.User);
        }
        
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookie");
        return Redirect("/");
    }

    private async Task<IActionResult> customLogin(string username, Role role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role.ToString())
        };
        var claimIdentity = new ClaimsIdentity(claims, "Cookie");
        var claimPrincipal = new ClaimsPrincipal(claimIdentity);
        await HttpContext.SignInAsync("Cookie", claimPrincipal);

        return RedirectToAction("Index", "Home");
    }

}

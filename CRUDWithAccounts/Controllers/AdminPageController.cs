using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUDWithAccounts.Controllers;

[Authorize(Roles = "Admin")]
public class AdminPageController : Controller
{
    public IActionResult AdminPage()
    {
        return View();
    }
    public IActionResult AddDiskPage()
    {
        return View();
    }
}

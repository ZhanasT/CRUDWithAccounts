using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUDWithAccounts.Controllers;

[Authorize]
public class AccountPageController : Controller
{
    public IActionResult AccountPage() => View();
}

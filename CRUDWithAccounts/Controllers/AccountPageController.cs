using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.WebUtilities;

namespace CRUDWithAccounts.Controllers;

    [Authorize(Roles = "User")]
public class AccountPageController : Controller
{
    public IActionResult AccountPage() => View();
    public IActionResult ShoppingCart()
    {

        return View();
    }

}

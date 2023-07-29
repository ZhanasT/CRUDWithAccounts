using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Database.Entity;
using CRUDWithAccounts.ViewModels;

namespace CRUDWithAccounts.Controllers;

[Authorize(Roles = "User")]
public class AccountPageController : Controller
{
    public IActionResult AccountPage() 
    {
        var userViewModel = new UserWithRoleViewModel();
        userViewModel.Username = User.Identity.Name;
        var claims = ((ClaimsIdentity)User.Identity).Claims;
        string role = claims.Where(claim => claim.Type.Split('/').LastOrDefault() == "role").FirstOrDefault().Value;
        userViewModel.Role = role;
        return View(userViewModel);
    }
    public async Task<IActionResult> ShoppingCart()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri($"https://localhost:7091/api/ShoppingCartAPI/GetShoppingCart/{User.Identity.Name}");

            var response = await client.GetFromJsonAsync<List<Disk>>(client.BaseAddress);

            if (response is not null)
            {
                Console.WriteLine(response);
                return View(response);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }

}

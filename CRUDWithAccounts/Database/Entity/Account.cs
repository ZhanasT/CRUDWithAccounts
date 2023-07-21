using CRUDWithAccounts.Database.Enum;

namespace CRUDWithAccounts.Database.Entity;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; } 
}

using Database.Enum;

namespace Database.Entity;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; } 
}

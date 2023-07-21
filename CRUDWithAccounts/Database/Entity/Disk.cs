namespace CRUDWithAccounts.Database.Entity;

public class Disk
{
    public int Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public int? Capacity { get; set; }
    public int? ReadSpeed { get; set; }
    public int? WriteSpeed { get; set; }
    public int? Cost { get; set; }
}

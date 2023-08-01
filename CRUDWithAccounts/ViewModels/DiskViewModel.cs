namespace CRUDWithAccounts.ViewModels;

public class DiskViewModel
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int Capacity { get; set; }
    public int? ReadSpeed { get; set; }
    public int? WriteSpeed { get; set; }
    public int Cost { get; set; }
}

namespace Database.Entity;

public class SelectedDisk
{
    public int Id { get; set; }
    public Account account { get; set; }
    public Disk disk { get; set; }
}

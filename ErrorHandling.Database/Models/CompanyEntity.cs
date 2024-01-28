namespace ErrorHandling.Database.Models;

public class CompanyEntity
{
    public string? Description { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UserCountMax { get; internal set; }
}
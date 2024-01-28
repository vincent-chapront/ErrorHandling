namespace ErrorHandling.API.Models;

public class CompanyDto
{
    public string? Description { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UserCountMax { get; internal set; }
}
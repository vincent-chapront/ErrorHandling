namespace ErrorHandling.Service.Model;

public class CompanyAddModel
{
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int UserCountMax { get; set; }
}
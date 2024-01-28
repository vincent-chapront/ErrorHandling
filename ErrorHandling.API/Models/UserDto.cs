namespace ErrorHandling.API.Model;

public class UserDto
{
    public int CompanyId { get; internal set; }
    public string? Email { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
}
namespace ErrorHandling.Database.Models;

public class UserEntity
{
    public int CompanyId { get; set; }

    public string? Email { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsAdmin { get; set; } = false;
    public string UserName { get; internal set; }
    public string Password { get; internal set; }
}
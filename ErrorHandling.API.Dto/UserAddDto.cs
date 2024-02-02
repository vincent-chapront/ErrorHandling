using ErrorHandling.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ErrorHandling.API.Dto;

public class UserAddDto
{
    [Required]
    [CompanyMustExist(ErrorMessage = "The company does not exist")]
    public int CompanyId { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public DateTime? ExpirationDate { get; set; }

    [Required]
    public string? Name { get; set; }

    [Range(0, int.MaxValue)]
    public int QuotaInSecond { get; set; }

    [Required]
    public SubscriptionPlans SubscriptionPlans { get; set; }
}
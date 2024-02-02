using ErrorHandling.Service.Services;
using System.ComponentModel.DataAnnotations;

namespace ErrorHandling.API.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class CompanyMustExistAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var companyService = validationContext.GetService(typeof(ICompanyService)) as ICompanyService;
        ErrorMessage = ErrorMessageString;

        if (value is not int)
        {
            throw new ArgumentException("CompanyMustExistAttribute must apply to int");
        }

        if (!companyService.Exists((int)value))
        {
            return new ValidationResult(ErrorMessage, new string[] { validationContext.MemberName });
        }

        return ValidationResult.Success;
    }
}
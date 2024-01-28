using System.ComponentModel.DataAnnotations;

namespace ErrorHandling.API.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class IsRequiredAttribute : ValidationAttribute
{
    private readonly string comparisonProperty;
    private readonly object[] requiredValues;

    public IsRequiredAttribute(string comparisonProperty, object[] requiredValues)
    {
        this.comparisonProperty = comparisonProperty;
        this.requiredValues = requiredValues;

        if (requiredValues.Length == 0)
        {
            throw new ArgumentException("RequiredValues must not be empty");
        }

        if (requiredValues.Length > 0)
        {
            var t = requiredValues[0].GetType();
            if (requiredValues.Any(x => x.GetType() != t))
            {
                throw new ArgumentException("All RequiredValues must be of same type");
            }
        }
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var property = validationContext.ObjectType.GetProperty(comparisonProperty);
        if (property == null)
        {
            throw new ArgumentException($"Property {comparisonProperty} not found");
        }
        if (property.PropertyType != requiredValues[0].GetType())
        {
            throw new ArgumentException($"Property {comparisonProperty} ({property.PropertyType}) must be of same type as requiredvalues ({requiredValues[0].GetType()})");
        }
        var v = property.GetValue(validationContext.ObjectInstance);
        if (requiredValues.Contains(v) && value == null)
        {
            return new ValidationResult(ErrorMessage);
        }
        return ValidationResult.Success;
    }
}
using ErrorHandling.API.Dto;
using ErrorHandling.Service.Model;

namespace ErrorHandling.API.Converters;

internal static class CompanyConverters
{
    public static CompanyDto ToDto(this CompanyModel model)
    {
        return new CompanyDto
        {
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            UserCountMax = model.UserCountMax
        };
    }

    public static IEnumerable<CompanyDto> ToDto(this IEnumerable<CompanyModel> models)
    {
        return models.Select(entity => ToDto(entity));
    }

    public static CompanyAddModel ToModel(this CompanyAddDto dto)
    {
        return new CompanyAddModel
        {
            Description = dto.Description,
            Name = dto.Name,
            UserCountMax = dto.UserCountMax
        };
    }

    public static CompanyModel ToModel(this CompanyDto dto)
    {
        return new CompanyModel
        {
            Description = dto.Description,
            Id = dto.Id,
            Name = dto.Name,
            UserCountMax = dto.UserCountMax
        };
    }

    public static IEnumerable<CompanyModel> ToModel(this IEnumerable<CompanyDto> dtos)
    {
        return dtos.Select(model => ToModel(model));
    }
}
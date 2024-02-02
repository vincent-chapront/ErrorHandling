using ErrorHandling.API.Dto;
using ErrorHandling.Service.Model;

namespace ErrorHandling.API.Converters;

internal static class UserConverters
{
    public static UserDto ToDto(this UserModel model)
    {
        return new UserDto
        {
            Email = model.Email,
            Id = model.Id,
            Name = model.Name,
            CompanyId = model.CompanyId,
            IsAdmin = model.IsAdmin
        };
    }

    public static IEnumerable<UserDto> ToDto(this IEnumerable<UserModel> models)
    {
        return models.Select(model => ToDto(model));
    }

    public static UserModel ToModel(this UserDto dto)
    {
        return new UserModel
        {
            Email = dto.Email,
            Id = dto.Id,
            Name = dto.Name,
            CompanyId = dto.CompanyId,
            IsAdmin = dto.IsAdmin
        };
    }

    public static UserAddModel ToModel(this UserAddDto dto)
    {
        return new UserAddModel
        {
            Email = dto.Email,
            Name = dto.Name,
            CompanyId = dto.CompanyId,
            IsAdmin = dto.IsAdmin
        };
    }

    public static IEnumerable<UserModel> ToModel(this IEnumerable<UserDto> entities)
    {
        return entities.Select(entity => ToModel(entity));
    }
}
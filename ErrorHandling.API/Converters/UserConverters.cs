using ErrorHandling.API.Models;
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
            CompanyId = model.CompanyId
        };
    }

    public static IEnumerable<UserDto> ToDto(this IEnumerable<UserModel> models)
    {
        return models.Select(model => ToDto(model));
    }

    public static UserModel ToModel(this UserDto entity)
    {
        return new UserModel
        {
            Email = entity.Email,
            Id = entity.Id,
            Name = entity.Name,
            CompanyId = entity.CompanyId
        };
    }

    public static UserAddModel ToModel(this UserAddDto entity)
    {
        return new UserAddModel
        {
            Email = entity.Email,
            Name = entity.Name,
            CompanyId = entity.CompanyId
        };
    }

    public static IEnumerable<UserModel> ToModel(this IEnumerable<UserDto> entities)
    {
        return entities.Select(entity => ToModel(entity));
    }
}
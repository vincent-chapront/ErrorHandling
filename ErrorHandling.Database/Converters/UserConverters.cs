using ErrorHandling.Database.Models;
using ErrorHandling.Service.Model;

namespace ErrorHandling.Database.Converters;

internal static class UserConverters
{
    public static UserEntity ToEntity(this UserModel model)
    {
        return new UserEntity
        {
            Email = model.Email,
            Id = model.Id,
            Name = model.Name,
            CompanyId = model.CompanyId
        };
    }

    public static IEnumerable<UserEntity> ToEntity(this IEnumerable<UserModel> models)
    {
        return models.Select(model => ToEntity(model));
    }

    public static UserModel ToModel(this UserEntity entity)
    {
        return new UserModel
        {
            Email = entity.Email,
            Id = entity.Id,
            Name = entity.Name,
            CompanyId = entity.CompanyId
        };
    }

    public static IEnumerable<UserModel> ToModel(this IEnumerable<UserEntity> entities)
    {
        return entities.Select(entity => ToModel(entity));
    }
}
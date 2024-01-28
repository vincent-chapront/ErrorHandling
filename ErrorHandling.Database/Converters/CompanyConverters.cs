using ErrorHandling.Database.Models;
using ErrorHandling.Service.Model;

namespace ErrorHandling.Database.Converters;

internal static class CompanyConverters
{
    public static CompanyEntity ToEntity(this CompanyModel model)
    {
        return new CompanyEntity
        {
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            UserCountMax = model.UserCountMax
        };
    }

    public static IEnumerable<CompanyEntity> ToEntity(this IEnumerable<CompanyModel> models)
    {
        return models.Select(model => ToEntity(model));
    }

    public static CompanyModel ToModel(this CompanyEntity entity)
    {
        return new CompanyModel
        {
            Description = entity.Description,
            Id = entity.Id,
            Name = entity.Name,
            UserCountMax = entity.UserCountMax
        };
    }

    public static IEnumerable<CompanyModel> ToModel(this IEnumerable<CompanyEntity> entities)
    {
        return entities.Select(entity => ToModel(entity));
    }
}
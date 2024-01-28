using ErrorHandling.Database.Models;

namespace ErrorHandling.Database;

public interface IStorageDbService
{
    List<CompanyEntity> Companies { get; }
    List<UserEntity> Users { get; }
}

public class StorageDbService : IStorageDbService
{
    public StorageDbService()
    {
        Companies = Enumerable.Range(1, 5).Select(index =>
        {
            return new CompanyEntity
            {
                Id = index,
                Name = $"Company {index}",
                Description = $"Description of company {index}",
                UserCountMax = Random.Shared.Next(1, 10)
            };
        })
        .ToList();

        Users = Enumerable.Range(1, 5).Select(index =>
        {
            return new UserEntity
            {
                Id = index,
                Name = $"Company {index}",
                Email = $"user_{index}@example.com",
                CompanyId = Companies[Random.Shared.Next(0, Companies.Count)].Id
            };
        })
        .ToList();
    }

    public List<CompanyEntity> Companies { get; }
    public List<UserEntity> Users { get; }
}
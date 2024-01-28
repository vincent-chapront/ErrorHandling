using ErrorHandling.Database.Converters;
using ErrorHandling.Service.Model;

namespace ErrorHandling.Database.Services;

public interface IUserDbService
{
    List<UserModel> GetAll();
}

public class UserDbService : IUserDbService
{
    private readonly IStorageDbService _storageDbService;

    public UserDbService(IStorageDbService storageDbService)
    {
        _storageDbService = storageDbService;
    }

    public List<UserModel> GetAll()
    {
        return _storageDbService.Users.ToModel().ToList();
    }
}
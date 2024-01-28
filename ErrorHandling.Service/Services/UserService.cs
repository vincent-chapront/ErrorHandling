using ErrorHandling.Database.Services;
using ErrorHandling.Service.Model;

namespace ErrorHandling.Service.Services;

public interface IUserService
{
    List<UserModel> GetAll();
}

public class UserService : IUserService
{
    private readonly IUserDbService _userDbService;

    public UserService(IUserDbService userDbService)
    {
        _userDbService = userDbService;
    }

    public List<UserModel> GetAll()
    {
        return _userDbService.GetAll();
    }
}
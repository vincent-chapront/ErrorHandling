using ErrorHandling.Database.Services;
using ErrorHandling.Service.Model;
using ErrorHandling.Service.Model.Exceptions;

namespace ErrorHandling.Service.Services;

public interface IUserService
{
    Task<UserModel> AddAsync(UserAddModel model);

    Task<List<UserModel>> GetAllAsync();
}

public class UserService : IUserService
{
    private readonly IUserDbService _userDbService;

    public UserService(IUserDbService userDbService)
    {
        _userDbService = userDbService;
    }

    public async Task<UserModel> AddAsync(UserAddModel model)
    {
        if (await _userDbService.IsDuplicateEmailAsync(model.Email))
        {
            var exception = new BadRequestException("A user with the same email already exists");
            exception.Data.Add("model", model);
            throw exception;
        }
        return await _userDbService.AddAsync(model);
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        return await _userDbService.GetAllAsync();
    }


}
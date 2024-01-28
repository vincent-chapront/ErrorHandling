using ErrorHandling.Database.Converters;
using ErrorHandling.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace ErrorHandling.Database.Services;

public interface IUserDbService
{
    Task<UserModel> AddAsync(UserAddModel model);

    Task<List<UserModel>> GetAllAsync();

    Task<bool> IsDuplicateEmailAsync(string email);
}

public class UserDbService : IUserDbService
{
    private readonly ErrorHandlingDbContext _dbContext;

    public UserDbService(ErrorHandlingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserModel> AddAsync(UserAddModel model)
    {
        var entity = model.ToEntity();
        var res = await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        var resEntity = res.Entity;
        return resEntity.ToModel();
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        List<Models.UserEntity> userEntities = await _dbContext.Users.ToListAsync();
        return userEntities.ToModel().ToList();
    }

    public async Task<bool> IsDuplicateEmailAsync(string email)
    {
        return await _dbContext.Users.AnyAsync(x => x.Email == email);
    }
}
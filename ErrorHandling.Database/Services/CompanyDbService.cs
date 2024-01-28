using ErrorHandling.Database.Converters;
using ErrorHandling.Service.Model;
using ErrorHandling.Service.Model.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ErrorHandling.Database.Services;

public interface ICompanyDbService
{
    Task<CompanyModel> AddAsync(CompanyAddModel company);

    bool Exists(int id);

    Task<List<CompanyModel>> GetAllAsync();

    Task<CompanyModel> GetByIdAsync(int id);

    Task<bool> IsDuplicateNameAsync(string name);
}

public class CompanyDbService : ICompanyDbService
{
    private readonly ErrorHandlingDbContext _dbContext;

    public CompanyDbService(ErrorHandlingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CompanyModel> AddAsync(CompanyAddModel company)
    {
        var entity = company.ToEntity();
        var res = await _dbContext.Companies.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        var resEntity = res.Entity;
        return resEntity.ToModel();
    }

    public bool Exists(int id)
    {
        return _dbContext.Companies.Any(x => x.Id == id);
    }

    public async Task<List<CompanyModel>> GetAllAsync()
    {
        List<Models.CompanyEntity> companyEntities = await _dbContext.Companies.ToListAsync();
        return companyEntities.ToModel().ToList();
    }

    public async Task<CompanyModel> GetByIdAsync(int id)
    {
        var company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (company == null)
        {
            var exception = new NotFoundException("Company not found");
            exception.Data.Add("id", id);
            throw exception;
        }
        return company.ToModel();
    }

    public async Task<bool> IsDuplicateNameAsync(string name)
    {
        return await _dbContext.Companies.AnyAsync(x => x.Name == name);
    }
}
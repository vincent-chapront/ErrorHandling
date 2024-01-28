using ErrorHandling.Database.Services;
using ErrorHandling.Service.Model;
using ErrorHandling.Service.Model.Exceptions;

namespace ErrorHandling.Service.Services;

public interface ICompanyService
{
    Task<CompanyModel> AddAsync(CompanyAddModel company);

    bool Exists(int id);

    Task<List<CompanyModel>> GetAllAsync();

    Task<CompanyModel> GetByIdAsync(int id);
}

public class CompanyService : ICompanyService
{
    private readonly ICompanyDbService _companyDbService;

    public CompanyService(ICompanyDbService companyDbService)
    {
        _companyDbService = companyDbService;
    }

    public async Task<CompanyModel> AddAsync(CompanyAddModel company)
    {
        if (await _companyDbService.IsDuplicateNameAsync(company.Name))
        {
            var exception = new BadRequestException("A company of the same name already exists");
            exception.Data.Add("model", company);
            throw exception;
        }
        return await _companyDbService.AddAsync(company);
    }

    public bool Exists(int id)
    {
        return _companyDbService.Exists(id);
    }

    public async Task<List<CompanyModel>> GetAllAsync()
    {
        return await _companyDbService.GetAllAsync();
    }

    public async Task<CompanyModel> GetByIdAsync(int id)
    {
        return await _companyDbService.GetByIdAsync(id);
    }
}
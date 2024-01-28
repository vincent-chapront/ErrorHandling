using ErrorHandling.Database.Converters;
using ErrorHandling.Service.Model;

namespace ErrorHandling.Database.Services;

public interface ICompanyDbService
{
    List<CompanyModel> GetAll();
}

public class CompanyDbService : ICompanyDbService
{
    private readonly IStorageDbService _storageDbService;

    public CompanyDbService(IStorageDbService storageDbService)
    {
        _storageDbService = storageDbService;
    }

    public List<CompanyModel> GetAll()
    {
        return _storageDbService.Companies.ToModel().ToList();
    }
}
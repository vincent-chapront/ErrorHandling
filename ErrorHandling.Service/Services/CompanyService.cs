using ErrorHandling.Database.Services;
using ErrorHandling.Service.Model;

namespace ErrorHandling.Service.Services;

public interface ICompanyService
{
    List<CompanyModel> GetAll();
}

public class CompanyService : ICompanyService
{
    private readonly ICompanyDbService _companyDbService;

    public CompanyService(ICompanyDbService companyDbService)
    {
        _companyDbService = companyDbService;
    }

    public List<CompanyModel> GetAll()
    {
        return _companyDbService.GetAll();
    }
}
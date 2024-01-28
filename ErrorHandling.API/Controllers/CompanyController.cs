using ErrorHandling.API.Model;
using ErrorHandling.API.Converters;
using ErrorHandling.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.API.Controllers;

[ApiController]
[Route("company")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public ActionResult<List<CompanyDto>> GetAll()
    {
        var companies = _companyService.GetAll();
        return companies.ToDto().ToList();
    }
}
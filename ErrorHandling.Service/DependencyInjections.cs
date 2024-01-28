using ErrorHandling.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandling.Service;

public static class DependencyInjections
{
    public static IServiceCollection AddServiceInjection(this IServiceCollection service)
    {
        service.AddDbServiceInjection();
        service.AddScoped<ICompanyService, CompanyService>();
        service.AddScoped<IUserService, UserService>();
        return service;
    }
}
using ErrorHandling.Database;
using ErrorHandling.Database.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandling.Service
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDbServiceInjection(this IServiceCollection service)
        {
            service.AddScoped<ICompanyDbService, CompanyDbService>();
            service.AddScoped<IUserDbService, UserDbService>();
            service.AddSingleton<ErrorHandlingDbContext>();
            return service;
        }
    }
}
using Auto.Application.Common.Interfaces.Authentication;
using Auto.Application.Common.Interfaces.Persistence;
using Auto.Application.Common.Interfaces.Services;
using Auto.Infrastructure.Authentication;
using Auto.Infrastructure.Persistence;
using Auto.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auto.Infrastructure;
public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration)
    {
        service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        service.AddScoped<IUserRepository, UserRepository>();
        return service;
    }
}
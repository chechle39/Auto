using Auto.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Auto.Application;
public static class DependencyInjection 
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        return service;
    }
}
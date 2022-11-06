using Auto.Application.Services.Authentication.Commands;
using Auto.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auto.Application;
public static class DependencyInjection 
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        //service.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        //service.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        service.AddMediatR(typeof(DependencyInjection).Assembly);
        return service;
    }
}
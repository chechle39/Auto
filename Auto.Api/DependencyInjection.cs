using Auto.Api.Common.Errors;
using Auto.Api.Common.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

namespace Auto.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddSingleton<ProblemDetailsFactory, AutoProblemDetailFactory>();
            service.AddMappings();
            return service;
        }
    }
}

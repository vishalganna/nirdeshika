using Microsoft.Extensions.DependencyInjection;
using Nirdeshika.Application.Services;
using Nirdeshika.Infrastructure.Data;
using Nirdeshika.Infrastructure.Repositories;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Infrastructure.Services;

namespace Nirdeshika.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddScoped<IConnectionFactory, ConnectionFactory>()
            .AddScoped<IRelationTypeRepository, RelationTypeRepository>()
            .AddScoped<ISurnameRepository, SurnameRepository>()
            ;

        services
            .AddScoped<ISurnameService, SurnameService>()
            ;
        return services;
    }
}

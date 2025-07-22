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
            .AddScoped<INativeRepository, NativeRepository>()
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<IFamilyRepository, FamilyRepository>()
            .AddScoped<IFamilyMemberRepository, FamilyMemberRepository>()
            ;

        services
            .AddScoped<ISurnameService, SurnameService>()
            .AddScoped<INativeService, NativeService>()
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<IFamilyService, FamilyService>()
            .AddScoped<IFamilyMemberService, FamilyMemberService>()
            .AddScoped<IRelationTypeService, RelationTypeService>()
            ;
        return services;
    }
}

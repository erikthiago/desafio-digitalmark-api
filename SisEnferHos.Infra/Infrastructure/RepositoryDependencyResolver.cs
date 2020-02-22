using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using SistEnferHos.Domain.Helpers.Interfaces;
using SistEnferHos.Infra.Contexts;
using SistEnferHos.Infra.UOW;
using System;
using System.Reflection;

namespace SistEnferHos.Infra.Infrastructure
{
    public static class RepositoryDependencyResolver
    {
        private static readonly Func<IServiceProvider, EntityContext> repoFactoryEntity = (_) =>
        {
            return new EntityContext();
        };

        private static readonly Func<IServiceProvider, DapperContext> repoFactoryDapper = (_) =>
        {
            return new DapperContext();
        };

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<EntityContext>(repoFactoryEntity);
            services.AddScoped<DapperContext>(repoFactoryDapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services
                .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }
    }
}

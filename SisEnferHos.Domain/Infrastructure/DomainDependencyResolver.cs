using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace SistEnferHos.Domain.Infrastructure
{
    public static class DomainDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services
                .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("CommandHandler"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
        }
    }
}

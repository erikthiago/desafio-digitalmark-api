using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SistEnferHos.Domain.Infrastructure;
using SistEnferHos.Infra.Infrastructure;

namespace SistEnferHos.API.Helpers
{
    public class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            DomainDependencyResolver.RegisterServices(services);
            RepositoryDependencyResolver.RegisterServices(services);
        }
    }
}

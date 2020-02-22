using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistEnferHos.API.Helpers;
using Swashbuckle.AspNetCore.Swagger;

namespace SistEnferHos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DependencyResolver.RegisterServices(services);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowDev",
                 builder => builder.WithOrigins("*").AllowAnyHeader()
                    .AllowAnyMethod()
                 );
            });


            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Sistema Gerenciador de Enfermeiros", Version = "v1", Description = "Exemplo de como fazer requisições http para a api" });
                // x.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Bearer Token", Name = "Authorization", Type = "apiKey" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowDev");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SisEnferHos - V1");
            });

            app.UseMvc();
        }
    }
}

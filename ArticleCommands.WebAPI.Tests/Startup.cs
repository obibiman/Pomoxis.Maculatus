using ArticleCommands.WebAPI.Database;
using ArticleCommands.WebAPI.Database.Contracts;
using ArticleCommands.WebAPI.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ArticleCommands.WebAPI.Tests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("ArticleCommands.WebAPI")).AddControllersAsServices();
            services.AddDbContext<FrontierContext>(options => options.UseInMemoryDatabase("ArticleCommandDb-" + Guid.NewGuid()), ServiceLifetime.Singleton);
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
using ArticleCommands.WebAPI.Database;
using ArticleCommands.WebAPI.Database.Contracts;
using ArticleCommands.WebAPI.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace ArticleCommands.WebAPI
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
            services.AddControllers();

            #region addlogging with serilog and seq

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
             .Enrich.WithProperty("Project", "ArticleCommands.WebAPI")
             .Enrich.WithProperty("Environment", "Local")
             .WriteTo.Seq("http://localhost:5341/")
             .CreateLogger();

            services.AddSingleton<Serilog.ILogger>(Log.Logger);

            #endregion addlogging with serilog and seq

            services.AddDbContext<FrontierContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ArticleData")));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            // Add framework services.
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Article Commands API", Description = "ArticleCommandsAPI", Version = "v1" });

                //var xmlPath = AppDomain.CurrentDomain.BaseDirectory + @"SwaggerDemo.CoreAPI.xml";
                //c.IncludeXmlComments(xmlPath);
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
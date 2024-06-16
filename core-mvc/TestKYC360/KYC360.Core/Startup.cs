using KYC360.Commons.Mapper;
using KYC360.Core.Data;
using KYC360.Core.Mappings;
using KYC360.Core.Models;
using KYC360.Core.Services;
using KYC360.Core.Configurations;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options; 
namespace KYC360.Core
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();

            // Register configuration settings
            services.Configure<RetryPolicySettings>(Configuration.GetSection("RetryPolicy"));

            services.AddSingleton(typeof(GenericMockDatabase<,>), provider =>
            {
                var logger = provider.GetRequiredService<ILogger<GenericMockDatabase<Entity, string>>>();
                var settings = provider.GetRequiredService<IOptions<RetryPolicySettings>>().Value;
                return new GenericMockDatabase<Entity, string>(logger, settings.MaxRetryAttempts, settings.InitialDelay, settings.MaxDelay, settings.BackoffFactor);
            });

            services.AddScoped<EntityService>();
            services.AddScoped(typeof(GenericMapper<,>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KYC360 API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
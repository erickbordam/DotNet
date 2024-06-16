using KYC360.Commons.Mapper;
using KYC360.Core.Data;
using KYC360.Core.Mappings;
using KYC360.Core.Services;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KYC360 API", Version = "v1" });
            });
            services.AddLogging();

            // Register AutoMapper with profiles
            services.AddAutoMapper(typeof(EntityMappingProfile));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddSingleton(typeof(GenericMockDatabase<,>), provider =>
            {
                var logger = provider.GetRequiredService<ILogger<GenericMockDatabase<Entity, string>>>();
                return new GenericMockDatabase<Entity, string>(logger, maxRetryAttempts: 3, initialDelay: 1000, maxDelay: 8000, backoffFactor: 2.0);
            });
            services.AddScoped<EntityService>();
            services.AddScoped(typeof(GenericMapper<,>));
            services.AddSingleton<DataSeeder>();  // Register the DataSeeder
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeeder dataSeeder, ILogger<Startup> logger)  // Inject DataSeeder
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "KYC360 API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            logger.LogInformation("Starting data seeding...");
            dataSeeder.Seed();  // Seed the data
            logger.LogInformation("Data seeding completed.");
        }
    }
}
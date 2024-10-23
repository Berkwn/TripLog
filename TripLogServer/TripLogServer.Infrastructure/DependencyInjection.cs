using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripLogServer.Domain.Repositories;
using TripLogServer.Infrastructure.Abstractions;
using TripLogServer.Infrastructure.Context;
using TripLogServer.Infrastructure.Services;

namespace TripLogServer.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

           

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITripContentRepository, TripContentRepository>();
            services.AddScoped<IFileStorageService, FileStorageService>();



            return services;
        

        }

        
    }
}

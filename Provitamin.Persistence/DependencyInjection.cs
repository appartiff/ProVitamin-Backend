using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Provitamin.Application.Common.Interfaces;

namespace Provitamin.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            services.AddDbContext<ProVitaminDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ProVitaminDatabase"), contextOptionsBuilder => contextOptionsBuilder.EnableRetryOnFailure());
                
                services.AddScoped<IProVitaminDbContext>(provider => provider.GetService<ProVitaminDbContext>());
            });
            return services;
        }
    }
}
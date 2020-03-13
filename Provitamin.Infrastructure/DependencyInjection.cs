using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Protvitamin.Infrastructure.Identity;

namespace Protvitamin.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ProVitaminDatabase"), contextOptionsBuilder => contextOptionsBuilder.EnableRetryOnFailure());
            });
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.HealthCheck.interfaces;
using Infrastructure.repository;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static async Task AddInfrastructure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("HealthCheckDb")
                       .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))

            );

            //builder.EnrichNpgsqlDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();


        }
    }
    
}

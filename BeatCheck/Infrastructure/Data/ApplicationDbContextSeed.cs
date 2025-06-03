using Application.HealthCheck;
using Application.HealthCheck.EndPoint;
using Core.HealtCheckAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // V�rifie si la base contient d�j� des suites
            if (await context.HealthCheckSuites.AnyAsync())
                return;

            // Exemple de cr�ation d'une suite et d'un check
            var suite = new ApiHealthCheckSuite("API Demo");
            var check = new EndPointCheckType("Ping");
            suite.AddCheck(check);

            context.HealthCheckSuites.Add(suite);

            await context.SaveChangesAsync();
        }
    }
}
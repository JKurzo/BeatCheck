
using Application.HealthCheck;
using Application.HealthCheck.interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.Services.AddScoped<IHealthCheckService, HealthCheckService>();
        }
    }
}

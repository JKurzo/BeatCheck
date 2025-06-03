using Application.HealthCheck;
using Application.HealthCheck.EndPoint;
using Core.HealtCheckAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HealthCheckSuiteConfiguration : IEntityTypeConfiguration<HealthCheckSuite>
    {
        public void Configure(EntityTypeBuilder<HealthCheckSuite> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.TargetName)
                .IsRequired();
            builder.Property(p => p.TargetType)
                .IsRequired();

            builder.HasDiscriminator<string>("HealthCheckSuiteDiscriminator")
                .HasValue<ApiHealthCheckSuite>("API");
        }
    }
}

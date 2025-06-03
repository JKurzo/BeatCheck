using Core.HealtCheckAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.HealthCheck.EndPoint;

namespace Infrastructure.Data
{
    public class CheckTypeConfiguration : IEntityTypeConfiguration<CheckType>
    {
        public void Configure(EntityTypeBuilder<CheckType> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Type)
                .IsRequired();

            builder.HasDiscriminator<string>("CheckTypeDiscriminator")
                .HasValue<EndPointCheckType>("EndPoint");
        }
    }
}

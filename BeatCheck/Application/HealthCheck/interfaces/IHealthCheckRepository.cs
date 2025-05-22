using Application.HealthCheck.DTOs;
using Domain.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.interfaces
{
    public interface IHealthCheckRepository
    {
        Task<Guid> CreateSuiteAsync(HealthCheckSuite entity);
        Task<HealthCheckSuite?> GetSuiteAsync(Guid id);
        Task<IEnumerable<HealthCheckSuite>> GetAllSuitesAsync();
        Task<Guid> CreateDefinitionAsync(HealthCheckDefinition entity);
        Task<HealthCheckDefinition?> GetDefinitionAsync(Guid id);
        Task<Guid> UpdateSuiteAsync(HealthCheckSuite entity);
    }
}

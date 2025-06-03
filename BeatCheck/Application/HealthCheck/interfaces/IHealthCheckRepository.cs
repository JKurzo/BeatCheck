using Core.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.interfaces
{
    public interface IHealthCheckRepository
    {
        Task<int> CreateSuiteAsync(HealthCheckSuite entity);
        Task<HealthCheckSuite?> GetSuiteAsync(int id);
        Task<IEnumerable<HealthCheckSuite>> GetAllSuitesAsync();
        Task<int> CreateDefinitionAsync(CheckType entity);
        Task<CheckType?> GetDefinitionAsync(int id);
        Task<int> UpdateSuiteAsync(HealthCheckSuite entity);
    }
}

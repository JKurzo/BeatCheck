using Application.HealthCheck.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.interfaces
{
    public interface IHealthCheckService
    {
        Task<int> CreateSuiteAsync(CreateHealthCheckSuiteDto dto);
        Task<HealthCheckSuiteDto> GetSuiteAsync(Guid id);
        Task<IEnumerable<HealthCheckSuiteDto>> GetAllSuitesAsync();
        Task<int> CreateDefinitionAsync(CreateCheckTypeDto dto);

    }
}

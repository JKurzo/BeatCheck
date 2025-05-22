using Application.HealthCheck.DTOs;
using Application.HealthCheck.interfaces;
using AutoMapper;
using Domain.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository healthCheckRepository;
        private readonly Mapper mapper;
        public HealthCheckService(IHealthCheckRepository healthCheckRepository)
        {
            healthCheckRepository = healthCheckRepository ?? throw new ArgumentNullException(nameof(healthCheckRepository));
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HealthCheckSuiteDto, HealthCheckSuite>();
                cfg.CreateMap<HealthCheckDefinitionDto, HealthCheckDefinition>();
            }));

        }
        public async Task<Guid> CreateDefinitionAsync(CreateHealthCheckDefinitionDto dto)
        {
            var suite = await healthCheckRepository.GetSuiteAsync(dto.HealthCheckSuiteId);
            if (suite == null)
            {
                throw new ArgumentException($"Health check suite with ID {dto.HealthCheckSuiteId} not found.");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(dto.Config))
            {
                parameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, string>>(dto.Config);
            }
            var definition = HealthCheckDefinitionFactory.Create(dto.CheckType, parameters);
            suite.AddCheck(definition);

            await healthCheckRepository.UpdateSuiteAsync(suite);
            return suite.Id;

        }

        public async Task<Guid> CreateSuiteAsync(CreateHealthCheckSuiteDto dto)
        {
            var suite = new ApiHealthCheckSuite(dto.TargetName);
            return await healthCheckRepository.CreateSuiteAsync(suite);
        }

        public Task<IEnumerable<HealthCheckSuiteDto>> GetAllSuitesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HealthCheckSuiteDto> GetSuiteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

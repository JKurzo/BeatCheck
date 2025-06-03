using Application.HealthCheck.DTOs;
using Application.HealthCheck.EndPoint;
using Application.HealthCheck.interfaces;
using AutoMapper;
using Core.HealtCheckAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepository;
        private readonly Mapper mapper;
        public HealthCheckService(IHealthCheckRepository healthCheckRepository)
        {
            _healthCheckRepository = healthCheckRepository ?? throw new ArgumentNullException(nameof(healthCheckRepository));
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HealthCheckSuite, HealthCheckSuiteDto>();
                cfg.CreateMap<CheckTypeDto, CheckType>();
                cfg.CreateMap<CheckType, CheckTypeDto>()
                    .ForMember(dest => dest.Config, opt => opt.MapFrom<CheckTypeConfigResolver>());
            }));
        }

        public async Task<int> CreateDefinitionAsync(CreateCheckTypeDto dto)
        {
            var suite = await _healthCheckRepository.GetSuiteAsync(dto.HealthCheckSuiteId);
            if (suite == null)
            {
                throw new ArgumentException($"Health check suite with ID {dto.HealthCheckSuiteId} not found.");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(dto.Config))
            {
                parameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, string>>(dto.Config);
            }
            var definition = CheckTypeFactory.Create(dto.CheckType, parameters);
            suite.AddCheck(definition);

            await _healthCheckRepository.UpdateSuiteAsync(suite);
            return suite.Id;
        }

        public async Task<int> CreateSuiteAsync(CreateHealthCheckSuiteDto dto)
        {
            var suite = new ApiHealthCheckSuite(dto.TargetName);
            return await _healthCheckRepository.CreateSuiteAsync(suite);
        }

        public async Task<IEnumerable<HealthCheckSuiteDto>> GetAllSuitesAsync()
        {
            var suites = await _healthCheckRepository.GetAllSuitesAsync();
            var suiteMap = mapper.Map<IEnumerable<HealthCheckSuiteDto>>(suites);
            return suiteMap;
        }

        public Task<HealthCheckSuiteDto> GetSuiteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

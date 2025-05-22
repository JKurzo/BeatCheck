using Application.HealthCheck.interfaces;
using AutoMapper;
using Domain.HealtCheckAggregate;
using Infrastructure.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.repository
{
    internal class HealthCheckRepository : IHealthCheckRepository
    {
        HealthCheckRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HealthCheckSuiteEntity, HealthCheckSuite>();
                cfg.CreateMap<HealthCheckDefinitionEntity, HealthCheckDefinition>();
            }));
        }
        private readonly AppDbContext _appDbContext;
        private readonly Mapper _mapper;

        public async Task<Guid> CreateSuiteAsync(HealthCheckSuite entity)
        {
            HealthCheckSuiteEntity healthCheckSuiteEntity = _mapper.Map<HealthCheckSuiteEntity>(entity);
            healthCheckSuiteEntity.Id = Guid.NewGuid();
            await _appDbContext.HealthCheckSuites.AddAsync(healthCheckSuiteEntity);
            await _appDbContext.SaveChangesAsync();
            return healthCheckSuiteEntity.Id;
        }

        public async Task<Guid> UpdateSuiteAsync(HealthCheckSuite entity)
        {
            HealthCheckSuiteEntity healthCheckSuiteEntity = _mapper.Map<HealthCheckSuiteEntity>(entity);
            _appDbContext.HealthCheckSuites.Update(healthCheckSuiteEntity);
            await _appDbContext.SaveChangesAsync();
            return healthCheckSuiteEntity.Id;
        }

        public async Task<HealthCheckSuite?> GetSuiteAsync(Guid id)
        {
            return await _appDbContext.HealthCheckSuites
                                        .Include(h => h.Checks)
                                        .Where(h => h.Id == id)
                                        .Select(h => _mapper.Map<HealthCheckSuite>(h))
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HealthCheckSuite>> GetAllSuitesAsync()
        {
            return await _appDbContext.HealthCheckSuites
                .Include(h => h.Checks)
                .Select(h => _mapper.Map<HealthCheckSuite>(h))
                .ToListAsync();
        }

        public async Task<Guid> CreateDefinitionAsync(HealthCheckDefinition entity)
        {
            HealthCheckDefinitionEntity healthCheckDefinitionEntity = _mapper.Map<HealthCheckDefinitionEntity>(entity);
            healthCheckDefinitionEntity.Id = Guid.NewGuid();
            await _appDbContext.HealthCheckDefinitions.AddAsync(healthCheckDefinitionEntity);
            await _appDbContext.SaveChangesAsync();
            return healthCheckDefinitionEntity.Id;
        }

        public async Task<HealthCheckDefinition?> GetDefinitionAsync(Guid id)
        {
            return await _appDbContext.HealthCheckDefinitions
                .Where(h => h.Id == id)
                .Select(h => _mapper.Map<HealthCheckDefinition>(h))
                .FirstOrDefaultAsync();
        }
    }
}

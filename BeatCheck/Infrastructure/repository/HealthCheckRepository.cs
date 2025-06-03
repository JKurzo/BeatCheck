using Application.HealthCheck.DTOs;
using Application.HealthCheck.interfaces;
using AutoMapper;
using Core.HealtCheckAggregate;
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
        public HealthCheckRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HealthCheckSuiteDto, HealthCheckSuite>();
                cfg.CreateMap<CheckType, CheckTypeDto>();
            }));
        }
        private readonly ApplicationDbContext _appDbContext;
        private readonly Mapper _mapper;

        public async Task<int> CreateSuiteAsync(HealthCheckSuite entity)
        {
            await _appDbContext.HealthCheckSuites.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> UpdateSuiteAsync(HealthCheckSuite entity)
        {
            _appDbContext.HealthCheckSuites.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<HealthCheckSuite?> GetSuiteAsync(int id)
        {
            return await _appDbContext.HealthCheckSuites
                                        .Include(h => h.Checks)
                                        .Where(h => h.Id == id)
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HealthCheckSuite>> GetAllSuitesAsync()
        {
            var suites = await _appDbContext.HealthCheckSuites
                .Include(h => h.Checks)
                .ToListAsync();

            return suites;
        }

        public async Task<int> CreateDefinitionAsync(CheckType entity)
        {
            await _appDbContext.HealthCheckDefinitions.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<CheckType?> GetDefinitionAsync(int id)
        {
            return await _appDbContext.HealthCheckDefinitions
                .Where(h => h.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}

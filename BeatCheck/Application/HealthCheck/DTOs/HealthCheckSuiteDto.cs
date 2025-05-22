using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.DTOs
{
    public class HealthCheckSuiteDto
    {
        public Guid Id { get; set; }
        public string TargetName { get; set; } = string.Empty;
        public string TargetType { get; set; } = string.Empty;
        public List<HealthCheckDefinitionDto> HealthCheckDefinitions { get; set; } = new List<HealthCheckDefinitionDto>();
    }
}

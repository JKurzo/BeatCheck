using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.DTOs
{
    public class HealthCheckSuiteDto
    {
        public int Id { get; set; }
        public string TargetName { get; set; } = string.Empty;
        public string TargetType { get; set; } = string.Empty;
        public List<CheckTypeDto> Checks { get; set; } = new List<CheckTypeDto>();
    }
}

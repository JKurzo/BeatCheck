using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.DTOs
{
    public class CreateCheckTypeDto
    {
        public string CheckType { get; set; }
        public required string Config { get; set; } // JSON configuration for the check
        public int HealthCheckSuiteId { get; set; } // Foreign key to HealthCheckSuiteEntity
    }
}

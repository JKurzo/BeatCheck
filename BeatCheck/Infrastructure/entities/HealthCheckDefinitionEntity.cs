using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.entities
{
    public class HealthCheckDefinitionEntity
    {
        public Guid Id { get; set; }
        public string CheckType { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public string? Config { get; set; } // JSON configuration for the check
        public Guid HealthCheckSuiteId { get; set; } // Foreign key to HealthCheckSuiteEntity
        public HealthCheckSuiteEntity? HealthCheckSuite { get; set; } // Navigation property
    }
}

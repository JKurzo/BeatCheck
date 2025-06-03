using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.DTOs
{
    public class CheckTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public Dictionary<string, string>? Config { get; set; } // JSON configuration for the check
        public int HealthCheckSuiteId { get; set; } // Foreign key to HealthCheckSuiteEntity
    }
}

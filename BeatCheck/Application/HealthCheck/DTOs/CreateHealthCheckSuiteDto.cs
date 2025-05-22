using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck
{
    public class CreateHealthCheckSuiteDto
    {
        public string TargetName { get; set; } = string.Empty;
        public string TargetType { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.entities
{
    public class HealthCheckSuiteEntity
    {
        public Guid Id { get; set; }
        public string TargetName { get; set; }
        public string TargetType { get; set; }
        public List<HealthCheckDefinitionEntity> Checks { get; set; } = new()
    }
}

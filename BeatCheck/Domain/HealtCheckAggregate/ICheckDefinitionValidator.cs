using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.HealtCheckAggregate
{
    public interface ICheckDefinitionValidator
    {
        bool IsValid(HealthCheckSuite suite, HealthCheckDefinition definition, out string? errorMessage);
    }
}

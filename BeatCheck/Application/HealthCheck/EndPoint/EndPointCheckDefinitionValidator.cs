using Domain.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.EndPoint
{
    public class EndPointCheckDefinitionValidator : ICheckDefinitionValidator
    {
        public bool IsValid(HealthCheckSuite suite, HealthCheckDefinition definition, out string? errorMessage)
        {
            errorMessage = null;
            if (definition is not EndPointHealthCheckDefinition apiCheck)
            {
                errorMessage = "Invalid check type for EndPointCheckDefinitionValidator.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(apiCheck.Url))
            {
                errorMessage = "URL cannot be null or empty.";
                return false;
            }
            if(suite.Checks.Any(c => c is EndPointHealthCheckDefinition existingCheck && existingCheck.Url == apiCheck.Url))
            {
                errorMessage = $"Duplicate URL found: {apiCheck.Url}";
                return false;
            }
            return true;
        }
    }
}

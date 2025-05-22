using Application.HealthCheck.EndPoint;
using Domain.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck
{
    internal class ApiHealthCheckSuite : HealthCheckSuite
    {
        public ApiHealthCheckSuite(string targetName) : base(targetName, "API")
        {
        }

        private static readonly Dictionary<string, ICheckDefinitionValidator> _validators = new()
        {
            {"EndPoint", new EndPointCheckDefinitionValidator()}
        };
    }
}

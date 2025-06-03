using Application.HealthCheck.EndPoint;
using Core.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck
{
    public class ApiHealthCheckSuite : HealthCheckSuite
    {
        public ApiHealthCheckSuite(string targetName) : base(targetName, "API")
        {
            _validators.Add("EndPoint", new EndPointCheckTypeValidator());
        }
    }
}

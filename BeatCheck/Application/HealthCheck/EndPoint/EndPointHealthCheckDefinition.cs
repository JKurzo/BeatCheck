using Domain.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.EndPoint
{
    internal class EndPointHealthCheckDefinition : HealthCheckDefinition
    {
        public string Url { get; private set; }
        public EndPointHealthCheckDefinition(string url, string status, string details)
            : base("EndPoint", status, details)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
    }
}

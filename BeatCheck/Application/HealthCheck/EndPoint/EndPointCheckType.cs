using Core.HealtCheckAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.EndPoint
{
    public class EndPointCheckType : CheckType
    {
        public string Url { get; private set; }
        public EndPointCheckType(string url)
            : base("EndPoint")
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
    }
}

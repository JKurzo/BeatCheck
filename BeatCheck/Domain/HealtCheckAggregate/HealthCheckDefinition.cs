using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.HealtCheckAggregate
{
    public abstract class HealthCheckDefinition
    {
        public string CheckType { get; private set; }
        public string Status { get; private set; }
        public string Details { get; private set; }

        public HealthCheckDefinition(string checkType, string status, string details)
        {
            CheckType = checkType ?? throw new ArgumentNullException(nameof(checkType));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Details = details ?? throw new ArgumentNullException(nameof(details));
        }
    }
}

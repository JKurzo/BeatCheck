using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HealtCheckAggregate
{
    public abstract class CheckType
    {
        public int Id { get; set; }
        public string Type { get; private set; }
        public string? Status { get; private set; }
        public string? Details { get; private set; }

        public CheckType(string type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Status = "Pending";
            Details = "Just added";
        }
        public void UpdateStatus(string status,  string details)
        {
            Status = status;
            Details = details;
        }
    }
}

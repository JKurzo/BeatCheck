using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HealtCheckAggregate
{
    public abstract class HealthCheckSuite
    {
        // Changed constructor from private to protected to allow access in derived classes
        protected HealthCheckSuite(string targetName, string targetType)
        {
            TargetName = targetName ?? throw new ArgumentNullException(nameof(targetName));
            TargetType = targetType ?? throw new ArgumentNullException(nameof(targetType));
        }

        public int Id { get; set; }
        public string TargetName { get; private set; }
        public string TargetType { get; private set; }

        protected readonly Dictionary<string, ICheckTypeValidator> _validators = new()
        {
            // add check definition here
        };
        private readonly List<CheckType> _checks = new();
        public IReadOnlyCollection<CheckType> Checks => _checks.AsReadOnly();

        public void AddCheck(CheckType check)
        {
            if (check == null) throw new ArgumentNullException(nameof(check));
            
            if (_validators.TryGetValue(check.Type, out var validator))
            {
                if (validator.IsValid(this, check, out var errorMessage))
                {
                    _checks.Add(check);
                }
                else
                {
                    throw new ArgumentException($"Invalid check definition: {errorMessage}");
                }
            }
            else
            {
                throw new ArgumentException($"Unknown check type: {check.Type}");
            }
        }
    }
}

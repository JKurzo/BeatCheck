using Application.HealthCheck.EndPoint;
using System;

namespace Domain.HealtCheckAggregate
{
    public static class HealthCheckDefinitionFactory
    {
        public static HealthCheckDefinition Create(string checkType, IDictionary<string, string> parameters)
        {
            return checkType switch
            {
                "API" => new EndPointHealthCheckDefinition(
                    parameters["Url"],
                    parameters["Status"],
                    parameters["Details"]),
                _ => throw new ArgumentException($"Unknow type checks: {checkType}")
            };
        }
    }
}
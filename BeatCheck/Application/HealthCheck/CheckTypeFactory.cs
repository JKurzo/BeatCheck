using Application.HealthCheck.EndPoint;
using Core.HealtCheckAggregate;
using System;

namespace Application.HealthCheck
{
    public static class CheckTypeFactory
    {
        public static CheckType Create(string checkType, IDictionary<string, string> parameters)
        {
            return checkType switch
            {
                "API" => new EndPointCheckType(
                    parameters["Url"]),
                _ => throw new ArgumentException($"Unknow type checks: {checkType}")
            };
        }
    }
}
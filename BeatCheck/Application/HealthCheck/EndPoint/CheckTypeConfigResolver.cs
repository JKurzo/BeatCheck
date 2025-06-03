using Application.HealthCheck.DTOs;
using AutoMapper;
using Core.HealtCheckAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HealthCheck.EndPoint
{
    public class CheckTypeConfigResolver : IValueResolver<CheckType, CheckTypeDto, Dictionary<string, string>?>
    {
        public Dictionary<string, string> Resolve(CheckType source, CheckTypeDto destination, Dictionary<string, string>? destMember, ResolutionContext context)
        {
            if (source is EndPointCheckType endpoint)
            {
                return new Dictionary<string, string>
                {
                    { "Url", endpoint.Url }
                };
            }
            return null;
        }
    }
}

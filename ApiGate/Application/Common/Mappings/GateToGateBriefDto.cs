using ApiGate.Application.Gates.Queries.GetGates;
using ApiGate.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Common.Mappings
{
    public class GateToGateBriefDto : Profile
    {
        public GateToGateBriefDto()
        {
            CreateMap<Gate, GateBriefDto>()
                .ForMember(dest => dest.ShortDescription, o => o.MapFrom(src => Converter(src)));
        }

        private static string Converter(Gate g)
        {
            if (g.Description.Length > 150)
            {
                return g.Description.Substring(0, 147) + "...";
            } else
            {
                return g.Description;
            }
        }
    }
}

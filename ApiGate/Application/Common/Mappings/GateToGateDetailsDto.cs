using ApiGate.Application.Gates.Queries.GetGateDetails;
using ApiGate.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Common.Mappings
{
    public class GateToGateDetailsDto : Profile
    {
        public GateToGateDetailsDto()
        {
            CreateMap<Gate, GateDetailsDto>();
        }
    }
}

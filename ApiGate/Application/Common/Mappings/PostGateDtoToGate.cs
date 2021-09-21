using ApiGate.Application.Gates.Commands.PostGate;
using ApiGate.Domain.Entities;
using ApiGate.Domain.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Common.Mappings
{
    public class PostGateDtoToGate : Profile
    {
        public PostGateDtoToGate()
        {
            CreateMap<PostGateDto, Gate>()
                .ForMember(d => d.Category, opt => opt.MapFrom(src => Converter(src)));
        }

        // This should take in a PostGateDto and return a correctly formatted Category.  Category should line up to one of our Gate Category Enum Values. 
        private static GateCategory Converter(PostGateDto g)
        {
            var correctlyFormatedDtoCategory = g.Category.Trim(' ').Replace(' ', '_');
            return (GateCategory)Enum.Parse(typeof(GateCategory), correctlyFormatedDtoCategory, true);
        }
    }
}

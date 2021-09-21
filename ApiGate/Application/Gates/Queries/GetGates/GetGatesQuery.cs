using ApiGate.Domain.Entities;
using ApiGate.Infrastructure.Persistance;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Queries.GetGates
{
    public class GetGatesQuery : IRequest<List<GateBriefDto>>
    {
    }

    public class getGatesQueryHandler : IRequestHandler<GetGatesQuery, List<GateBriefDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public getGatesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
                
        public async Task<List<GateBriefDto>> Handle(GetGatesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Gates.ToListAsync();
            return entities.Select(_mapper.Map<GateBriefDto>).ToList();
        }
    }
}

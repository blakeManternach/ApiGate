using ApiGate.Infrastructure.Persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Queries.GetGateDetails
{
    public class GetGateDetailsQuery : IRequest<GateDetailsDto>
    {
        public int Id { get; internal set; }
    }

    public class GetGateDetailsQueryHandler : IRequestHandler<GetGateDetailsQuery, GateDetailsDto>
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetGateDetailsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // TODO: Needs Error Handling...what if find async returns null?
        public async Task<GateDetailsDto> Handle(GetGateDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Gates.FindAsync(request.Id);
            return _mapper.Map<GateDetailsDto>(entity);
        }
    }
}

using ApiGate.Application.Gates.Commands.PostGate;
using ApiGate.Domain.Entities;
using ApiGate.Infrastructure.Persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Commands.PostGateList
{
    public class PostGateListCommand : IRequest<int>
    {
        public List<PostGateDto> PostGateDtos { get; internal set; }
    }

    public class PostGateListCommandHandler : IRequestHandler<PostGateListCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostGateListCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(PostGateListCommand request, CancellationToken cancellationToken)
        {
            foreach (PostGateDto pgd in request.PostGateDtos)
            {
                await _context.Gates.AddAsync(_mapper.Map<Gate>(pgd));
            }
            return await _context.SaveChangesAsync();
        }
    }
}

using ApiGate.Domain.Entities;
using ApiGate.Domain.Enums;
using ApiGate.Infrastructure.Persistance;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Commands.PostGate
{
    public class PostGateCommand : IRequest<int>
    {
        public PostGateDto pgd { get; set; }
    }

    public class PostGateCommandHandler : IRequestHandler<PostGateCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PostGateCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Handle(PostGateCommand request, CancellationToken cancellationToken)
        {
            _context.Gates.Add(_mapper.Map<Gate>(request.pgd));
            return _context.SaveChangesAsync();
        }
    }
}

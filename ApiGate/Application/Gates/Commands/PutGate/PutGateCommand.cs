using ApiGate.Application.Gates.Commands.PostGate;
using ApiGate.Domain.Entities;
using ApiGate.Infrastructure.Persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Commands
{
    public class PutGateCommand : IRequest<int>
    {
        public int Id { get; internal set; }
        public PostGateDto pgd { get; internal set; }
    }

    public class PutGateCommandHandler : IRequestHandler<PutGateCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PutGateCommandHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(PutGateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Gates.FindAsync(request.Id);
            var postEntity = _mapper.Map<Gate>(request.pgd);

            entity.Name = postEntity.Name;
            entity.Url = postEntity.Url;
            entity.Year = postEntity.Year;
            entity.Description = postEntity.Description;
            entity.Country = postEntity.Country;
            entity.Category = postEntity.Category;

            return await _context.SaveChangesAsync();
        }
    }
}

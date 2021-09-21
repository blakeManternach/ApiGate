using ApiGate.Domain.Entities;
using ApiGate.Infrastructure.Persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Commands.DeleteGate
{
    public class DeleteGateCommand : IRequest<int>
    {
        public int Id { get; internal set; }
    }

    public class DeleteGateCommandHandler : IRequestHandler<DeleteGateCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteGateCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteGateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Gates.FindAsync(request.Id);
            _context.Gates.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}

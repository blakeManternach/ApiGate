using ApiGate.Domain.Entities;
using ApiGate.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGate.Application.Gates.Commands.DeleteAllGates
{
    public class DeleteAllGatesCommand : IRequest<int>
    {
    }

    public class DeleteAllGatesCommandHandler : IRequestHandler<DeleteAllGatesCommand, int>
    {
        private readonly ApplicationDbContext _context;
        public DeleteAllGatesCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteAllGatesCommand request, CancellationToken cancellationToken)
        {
            var entities = await _context.Gates.ToListAsync();
            foreach (var e in entities)
            {
                _context.Remove(e);
            }
            return await _context.SaveChangesAsync();
        }
    }
}

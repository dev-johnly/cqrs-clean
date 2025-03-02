using cqrs_clean.Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly AppDbContext _context;

    public DeleteUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

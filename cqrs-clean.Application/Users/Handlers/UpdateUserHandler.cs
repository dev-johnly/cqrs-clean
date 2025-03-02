using cqrs_clean.Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if (user == null) return false;

        user.FullName = request.FullName ?? user.FullName;
        user.IsActive = request.IsActive ?? user.IsActive;
        user.UpdatedAt = DateTime.UtcNow;

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

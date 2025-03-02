using cqrs_clean.Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly AppDbContext _context;

    public CreateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FullName = request.FullName,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}

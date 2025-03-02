using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly AppDbContext _context;

    public GetUserByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        return user == null ? null : new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
            IsActive = user.IsActive
        };
    }
}

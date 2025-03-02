using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly AppDbContext _context;

    public GetAllUsersHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                FullName = u.FullName,
                IsActive = u.IsActive
            })
            .ToListAsync(cancellationToken);
    }
}

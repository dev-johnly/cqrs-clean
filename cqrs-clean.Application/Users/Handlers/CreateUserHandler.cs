using Azure.Core;
using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.Commands;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse>
{
    private readonly AppDbContext _context;

    public CreateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //var user = new User
        //{
        //    Username = request.Username,
        //    Email = request.Email,
        //    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
        //    FullName = request.FullName,
        //    CreatedAt = DateTime.UtcNow,
        //    UpdatedAt = DateTime.UtcNow,
        //    IsActive = true
        //};
        var existingUser = await _context.Users
    .FirstOrDefaultAsync(u => u.Email == request.Email); // or Username, etc.

        if (existingUser is not null)
        {
            throw new ApplicationException("User already exists with that email.");
        }

        var user = request.Adapt<User>();
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return ApiResponse.SuccessResponse();
    }
}

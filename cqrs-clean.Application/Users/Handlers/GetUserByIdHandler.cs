using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Queries;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
{
    private readonly AppDbContext _context;

    public GetUserByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if (user == null) return ApiResponse<UserDto>.Failure("User not found");
        var userDto = user.Adapt<UserDto>();
        return ApiResponse<UserDto>.Success(userDto);
    }
}

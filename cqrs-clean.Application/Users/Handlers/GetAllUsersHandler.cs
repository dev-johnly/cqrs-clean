using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Queries;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PaginatedList<UserDto>>
{
    private readonly AppDbContext _context;

    public GetAllUsersHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await GetUsersAsync(request.PageIndex, request.SearchTerm);
    }

    private async Task<PaginatedList<UserDto>> GetUsersAsync(int pageIndex = 1, string? searchTerm = null)
    {
        var query = _context.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(u =>
                u.Username.Contains(searchTerm) ||
                u.Email.Contains(searchTerm) ||
                u.FullName.Contains(searchTerm) ||
                u.IsActive.ToString().Contains(searchTerm));
        }

        return await PaginatedList<UserDto>.CreateAsync(query.ProjectToType<UserDto>(), pageIndex);
    }
}

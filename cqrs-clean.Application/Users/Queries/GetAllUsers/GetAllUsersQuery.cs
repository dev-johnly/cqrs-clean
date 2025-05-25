using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<PaginatedList<UserDto>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }

}

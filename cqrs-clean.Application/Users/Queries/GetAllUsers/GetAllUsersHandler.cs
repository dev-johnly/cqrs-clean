using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Interfaces;
using Mapster;
using MediatR;

namespace cqrs_clean.Application.Users.Queries.GetAllUsers;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PaginatedList<UserDto>>
{
    private readonly IUserService _userService;

    public GetAllUsersHandler(IUserService userService)
    {
        _userService = userService;
    }



    public async Task<PaginatedList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetPaginatedUsersAsync(
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            searchTerm: request.SearchTerm,
            cancellationToken: cancellationToken);
    }


}

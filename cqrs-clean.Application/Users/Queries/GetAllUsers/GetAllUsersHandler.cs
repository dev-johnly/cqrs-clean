using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Domain.Common.Interfaces;
using Mapster;
using MediatR;

namespace cqrs_clean.Application.Users.Queries.GetAllUsers;
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PaginatedList<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginatedList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Users
        .GetAll() 
        .Where(u => string.IsNullOrEmpty(request.SearchTerm) ||
                    u.Username.Contains(request.SearchTerm) ||
                    u.FullName.Contains(request.SearchTerm) ||
                    u.Email.Contains(request.SearchTerm))
        .ProjectToType<UserDto>(); 

        return await PaginatedList<UserDto>.CreateAsync(
            query,
            request.PageIndex,
            request.PageSize,
            cancellationToken);
    }


}

using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Domain.Common.Interfaces;
using MediatR;
using Mapster;
namespace cqrs_clean.Application.Users.Queries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWork.Users.GetByIdAsync(request.Id);

        var userdto = response.Adapt<UserDto>();
        return ApiResponse<UserDto>.Success(userdto);
    }
}

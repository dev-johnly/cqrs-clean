using cqrs_clean.Application.Common;
using cqrs_clean.Domain.Common.Interfaces;
using MediatR;

namespace cqrs_clean.Application.Users.Commands.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApiResponse>
{

    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Users.DeleteAsync(request.Id);
        return ApiResponse.SuccessResponse();
    }
}

using cqrs_clean.Application.Common;
using cqrs_clean.Domain.Common.Interfaces;
using Mapster;
using MediatR;

namespace cqrs_clean.Application.Users.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
        if (user == null) return ApiResponse.FailureResponse("Data not found");

        request.Adapt(user);
        await _unitOfWork.Users.UpdateAsync(user);

        return ApiResponse.SuccessResponse();
    }
}

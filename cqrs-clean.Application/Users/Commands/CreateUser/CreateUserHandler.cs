using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.Commands;
using cqrs_clean.Domain.Common.Interfaces;
using Mapster;
using MediatR;

namespace cqrs_clean.Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        IUnitOfWork _unitOfWork;
    }

    public async Task<ApiResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.Users.ExistsAsync(request.Email))
        {
            return ApiResponse.FailureResponse("User already exists with that email.");
        }

        var user = request.Adapt<User>();
        await _unitOfWork.Users.AddAsync(user);

        return ApiResponse.SuccessResponse();
    }
}

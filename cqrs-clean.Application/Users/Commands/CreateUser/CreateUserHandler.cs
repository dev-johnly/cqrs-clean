using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.Commands;
using cqrs_clean.Application.Users.Interfaces;
using Mapster;
using MediatR;

namespace cqrs_clean.Application.Users.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userService.ExistsAsync(request.Email))
        {
            return ApiResponse.FailureResponse("User already exists with that email.");
        }

        var user = request.Adapt<User>();
        await _userService.AddAsync(user);

        return ApiResponse.SuccessResponse();
    }
}

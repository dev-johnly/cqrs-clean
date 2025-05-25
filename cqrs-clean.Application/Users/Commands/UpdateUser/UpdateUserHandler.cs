using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApiResponse>
{
    private readonly IUserService _userService;

    public UpdateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsync(request.Id);
        if (user == null) return ApiResponse.FailureResponse("Data not found");

        request.Adapt(user);
        await _userService.UpdateAsync(user);

        return ApiResponse.SuccessResponse();
    }
}

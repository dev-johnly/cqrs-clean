using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.Commands;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApiResponse>
{
    private readonly AppDbContext _context;

    public UpdateUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if (user == null) return ApiResponse.FailureResponse("Data not found");

        request.Adapt(user);
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        return ApiResponse.SuccessResponse();
    }
}

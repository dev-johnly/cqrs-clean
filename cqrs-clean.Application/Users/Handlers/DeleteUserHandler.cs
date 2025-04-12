using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApiResponse>
{
    private readonly AppDbContext _context;

    public DeleteUserHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if (user == null) return ApiResponse.FailureResponse("Data not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return ApiResponse.SuccessResponse();
    }
}

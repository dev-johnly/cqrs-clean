using cqrs_clean.Application.Common;
using MediatR;

namespace cqrs_clean.Application.Users.Commands;

public class CreateUserCommand : IRequest<ApiResponse>
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? FullName { get; set; }
}

using cqrs_clean.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Commands;
public class UpdateUserCommand : IRequest<ApiResponse>
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public bool? IsActive { get; set; }
}

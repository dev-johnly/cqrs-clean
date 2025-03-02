using cqrs_clean.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>> { }

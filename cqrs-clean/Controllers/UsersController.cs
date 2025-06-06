﻿using cqrs_clean.Application.Users.Commands;
using cqrs_clean.Application.Users.Commands.DeleteUser;
using cqrs_clean.Application.Users.Commands.UpdateUser;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Queries;
using cqrs_clean.Application.Users.Queries.GetAllUsers;
using cqrs_clean.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_clean.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult<int>> CreateUser(CreateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("GetUserById/{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        return Ok(await _mediator.Send(new GetUserByIdQuery(id)));
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult<bool>> UpdateUser(UpdateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("DeleteUser/{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        return Ok(await _mediator.Send(new DeleteUserCommand { Id = id }));
    }
}

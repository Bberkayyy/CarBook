﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Tools;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignInController : ControllerBase
{
    private readonly IMediator _mediator;

    public SignInController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Login(GetCheckAppUserQuery query)
    {
        var value = await _mediator.Send(query);
        if (value.IsExist)
            return Created("", JwtTokenGenerator.GenerateToken(value));
        else
            return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
    }
}

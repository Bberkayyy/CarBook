﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> BlogList()
    {
        var values = await _mediator.Send(new GetBlogQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id)
    {
        var value = await _mediator.Send(new GetBlogByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Blog bilgisi eklendi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Blog bilgisi güncellendi.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBlog(int id)
    {
        await _mediator.Send(new RemoveBlogCommand(id));
        return Ok("Blog biligisi silindi.");
    }
    [HttpGet("GetLast3BlogsWithAuthors")]
    public async Task<IActionResult> GetLast3BlogsWithAuthors()
    {
        var values = await _mediator.Send(new GetLast3BlogsWithAuthorQuery());
        return Ok(values);
    }
    [HttpGet("GetAllBlogsWithAuthors")]
    public async Task<IActionResult> GetAllBlogsWithAuthors()
    {
        var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
        return Ok(values);
    }
    [HttpGet("GetBlogWithAuthorId")]
    public async Task<IActionResult> GetBlogWithAuthorId(int id)
    {
        var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
        return Ok(values);
    }
}

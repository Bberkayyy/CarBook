using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagCloudsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagCloudsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> TagCloudsList()
    {
        var values = await _mediator.Send(new GetTagCloudsQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagClouds(int id)
    {
        var value = await _mediator.Send(new GetTagCloudsByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTagClouds(CreateTagCloudsCommand command)
    {
        await _mediator.Send(command);
        return Ok("Etiket bilgisi eklendi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTagClouds(UpdateTagCloudsCommand command)
    {
        await _mediator.Send(command);
        return Ok("Etiket bilgisi güncellendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveTagClouds(int id)
    {
        await _mediator.Send(new RemoveTagCloudsCommand(id));
        return Ok("Etiket biligisi silindi.");
    }
    [HttpGet("GetTagCloudsByBlogId")]
    public async Task<IActionResult> GetTagCloudsByBlogId(int id)
    {
        var values = await _mediator.Send(new GetTagCloudsByBlogIdQuery(id));
        return Ok(values);
    }
}

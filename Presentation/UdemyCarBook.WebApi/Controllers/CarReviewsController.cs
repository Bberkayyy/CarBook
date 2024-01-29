using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarReviewCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarReviewQueries;
using UdemyCarBook.Application.Validators.CarReviewValidators;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarReviewsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> CarReviewListByCarId(int id)
    {
        var values = await _mediator.Send(new GetCarReviewByCarIdQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCarReview(CreateCarReviewCommand command)
    {
        CreateCarReviewValidator validator = new CreateCarReviewValidator();
        var validationResult = validator.Validate(command);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        await _mediator.Send(command);
        return Ok("Araç yorumu bilgisi eklendi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCarReview(UpdateCarReviewCommand command)
    {
        await _mediator.Send(command);
        return Ok("Araç yorumu bilgisi güncellendi.");
    }
}

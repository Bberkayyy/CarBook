﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarFeaturesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarFeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> CarFeatureListByCarId(int carId)
    {
        var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(carId));
        return Ok(values);
    }
    [HttpGet("AvailableToFalse")]
    public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
    {
        _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
        return Ok("Güncelleme başarılı.");
    }
    [HttpGet("AvailableToTrue")]
    public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
    {
        _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
        return Ok("Güncelleme başarılı.");
    }
    [HttpPost]
    public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
    {
        _mediator.Send(command);
        return Ok("Özellik eklendi.");
    }
}

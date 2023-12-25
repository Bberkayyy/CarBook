using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetCarCount")]
    public async Task<IActionResult> GetCarCount()
    {
        var value = await _mediator.Send(new GetCarCountQuery());
        return Ok(value);
    }
    [HttpGet("GetBlogTitleMaxBlogComment")]
    public async Task<IActionResult> GetBlogTitleMaxBlogComment()
    {
        var value = await _mediator.Send(new GetBlogTitleMaxBlogCommentQuery());
        return Ok(value);
    }
    [HttpGet("GetBrandNameByMaxCar")]
    public async Task<IActionResult> GetBrandNameByMaxCar()
    {
        var value = await _mediator.Send(new GetBrandNameByMaxCarQuery());
        return Ok(value);
    }
    [HttpGet("GetAuthorCount")]
    public async Task<IActionResult> GetAuthorCount()
    {
        var value = await _mediator.Send(new GetAuthorCountQuery());
        return Ok(value);
    }
    [HttpGet("GetAverageRentPriceForDaily")]
    public async Task<IActionResult> GetAverageRentPriceForDaily()
    {
        var value = await _mediator.Send(new GetAverageRentPriceForDailyQuery());
        return Ok(value);
    }
    [HttpGet("GetAverageRentPriceForMonthly")]
    public async Task<IActionResult> GetAverageRentPriceForMonthly()
    {
        var value = await _mediator.Send(new GetAverageRentPriceForMonthlyQuery());
        return Ok(value);
    }
    [HttpGet("GetAverageRentPriceForWeekly")]
    public async Task<IActionResult> GetAverageRentPriceForWeekly()
    {
        var value = await _mediator.Send(new GetAverageRentPriceForWeeklyQuery());
        return Ok(value);
    }
    [HttpGet("GetBlogCount")]
    public async Task<IActionResult> GetBlogCount()
    {
        var value = await _mediator.Send(new GetBlogCountQuery());
        return Ok(value);
    }
    [HttpGet("GetBrandCount")]
    public async Task<IActionResult> GetBrandCount()
    {
        var value = await _mediator.Send(new GetBrandCountQuery());
        return Ok(value);
    }
    [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
    public async Task<IActionResult> GetCarCouGetCarBrandAndModelByRentPriceDailyMaxnt()
    {
        var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
        return Ok(value);
    }
    [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
    public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
    {
        var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
        return Ok(value);
    }
    [HttpGet("GetCarCountByFuelElectric")]
    public async Task<IActionResult> GetCarCountByFuelElectric()
    {
        var value = await _mediator.Send(new GetCarCountByFuelElectricQuery());
        return Ok(value);
    }
    [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
    public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
    {
        var value = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
        return Ok(value);
    }
    [HttpGet("GetCarCountByKmLessThen1000")]
    public async Task<IActionResult> GetCarCountByKmLessThen1000()
    {
        var value = await _mediator.Send(new GetCarCountByKmLessThen1000Query());
        return Ok(value);
    }
    [HttpGet("GetCarCountByTransmissionIsAuto")]
    public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
    {
        var value = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
        return Ok(value);
    }
    [HttpGet("GetLocationCount")]
    public async Task<IActionResult> GetLocationCount()
    {
        var value = await _mediator.Send(new GetLocationCountQuery());
        return Ok(value);
    }
}

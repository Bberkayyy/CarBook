using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _carRepository;

    public GetCarByIdQueryHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var value = await _carRepository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            Id = value.Id,
            BigImageUrl = value.BigImageUrl,
            BrandId = value.BrandId,
            CoverImageUrl = value.CoverImageUrl,
            Fuel = value.Fuel,
            Km = value.Km,
            Luggage = value.Luggage,
            Model = value.Model,
            Seat = value.Seat,
            Transmission = value.Transmission,
        };
    }
}

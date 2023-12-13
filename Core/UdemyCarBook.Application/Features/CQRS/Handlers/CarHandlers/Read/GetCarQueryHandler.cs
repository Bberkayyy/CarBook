using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;

public class GetCarQueryHandler
{
    private readonly IRepository<Car> _carRepository;

    public GetCarQueryHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await _carRepository.GetAllAsync();
        return values
            .Select(x => new GetCarQueryResult
            {
                Id = x.Id,
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Model = x.Model,
                Transmission = x.Transmission,
            })
            .ToList();
    }
}

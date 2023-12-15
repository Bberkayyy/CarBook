using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;

public class GetLast5CarWithBrandQueryHandler
{
    private readonly ICarRepository _carRepository;

    public GetLast5CarWithBrandQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public  List<GetCarWithBrandQueryResult> Handle()
    {
        var values =  _carRepository.GetLast5CarsWithBrands();
        return values

            .Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
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

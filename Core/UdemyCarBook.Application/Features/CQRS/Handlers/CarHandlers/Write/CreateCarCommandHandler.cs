using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _carRepository;

    public CreateCarCommandHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task Handle(CreateCarCommand command)
    {
        await _carRepository.CreateAsync(new Car
        {
            BigImageUrl = command.BigImageUrl,
            Luggage=command.Luggage,
            Transmission=command.Transmission,
            Seat=command.Seat,
            Model=command.Model,
            Km=command.Km,
            Fuel=command.Fuel,
            CoverImageUrl=command.CoverImageUrl,
            BrandId=command.BrandId,
            
        });
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _carRepository;

    public UpdateCarCommandHandler(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task Handle(UpdateCarCommand command)
    {
        var value = await _carRepository.GetByIdAsync(command.Id);
        value.Fuel = command.Fuel;
        value.Seat = command.Seat;
        value.BigImageUrl = command.BigImageUrl;
        value.Luggage = command.Luggage;
        value.BrandId = command.BrandId;
        value.CoverImageUrl = command.CoverImageUrl;
        value.Km = command.Km;
        value.Model = command.Model;
        value.Transmission = command.Transmission;
        await _carRepository.UpdateAsync(value);
    }
}

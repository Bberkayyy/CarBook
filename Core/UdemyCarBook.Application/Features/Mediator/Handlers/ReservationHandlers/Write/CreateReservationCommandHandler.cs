using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers.Write;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IRepository<Reservation> _reservationRepository;

    public CreateReservationCommandHandler(IRepository<Reservation> reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationRepository.CreateAsync(new Reservation
        {
            Name = request.Name,
            Surname = request.Surname,
            Age = request.Age,
            Phone = request.Phone,
            CarId = request.CarId,
            Description = request.Description,
            DriverLicenseYear = request.DriverLicenseYear,
            Email = request.Email,
            DropOffLocationId = request.DropOffLocationId,
            PickUpLocationId = request.PickUpLocationId,
            Status = "Rezervasyon Alındı."
        });
    }
}

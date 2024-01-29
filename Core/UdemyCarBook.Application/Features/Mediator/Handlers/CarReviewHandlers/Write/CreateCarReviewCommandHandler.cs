using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarReviewHandlers.Write;

public class CreateCarReviewCommandHandler : IRequestHandler<CreateCarReviewCommand>
{
    private readonly IRepository<CarReview> _carReviewRepository;

    public CreateCarReviewCommandHandler(IRepository<CarReview> carReviewRepository)
    {
        _carReviewRepository = carReviewRepository;
    }

    public async Task Handle(CreateCarReviewCommand request, CancellationToken cancellationToken)
    {
        await _carReviewRepository.CreateAsync(new CarReview
        {
            CustomerName = request.CustomerName,
            CarId = request.CarId,
            Comment = request.Comment,
            CustomerImage = request.CustomerImage,
            RaytingValues = request.RaytingValues,
            ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
        });
    }
}

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

public class UpdateCarReviewCommandHandler : IRequestHandler<UpdateCarReviewCommand>
{
    private readonly IRepository<CarReview> _carReviewRepository;

    public UpdateCarReviewCommandHandler(IRepository<CarReview> carReviewRepository)
    {
        _carReviewRepository = carReviewRepository;
    }

    public async Task Handle(UpdateCarReviewCommand request, CancellationToken cancellationToken)
    {
        var values = await _carReviewRepository.GetByIdAsync(request.Id);
        values.CustomerName = request.CustomerName;
        values.CustomerImage = request.CustomerImage;
        values.CarId = request.CarId;
        values.Comment = request.Comment;
        values.ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        values.RaytingValues = request.RaytingValues;
        await _carReviewRepository.UpdateAsync(values);
    }
}

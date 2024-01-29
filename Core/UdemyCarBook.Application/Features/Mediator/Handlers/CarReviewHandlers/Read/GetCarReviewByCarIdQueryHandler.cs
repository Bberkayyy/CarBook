using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarReviewResults;
using UdemyCarBook.Application.Interfaces.CarReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarReviewHandlers.Read;

public class GetCarReviewByCarIdQueryHandler : IRequestHandler<GetCarReviewByCarIdQuery, List<GetCarReviewByCarIdQueryResult>>
{
    private readonly ICarReviewRepository _carReviewRepository;

    public GetCarReviewByCarIdQueryHandler(ICarReviewRepository carReviewRepository)
    {
        _carReviewRepository = carReviewRepository;
    }

    public async Task<List<GetCarReviewByCarIdQueryResult>> Handle(GetCarReviewByCarIdQuery request, CancellationToken cancellationToken)
    {
        var values = _carReviewRepository.GetCarReviewsByCarId(request.Id);
        return values.Select(x => new GetCarReviewByCarIdQueryResult
        {
            Comment = x.Comment,
            CustomerImage = x.CustomerImage,
            CustomerName = x.CustomerName,
            RaytingValues = x.RaytingValues,
            ReviewDate = x.ReviewDate,
            Id = x.Id,
            CarId = x.CarId
        }).ToList();
    }
}
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers.Read;

public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
{
    private readonly ICarDescriptionRepository _carDescriptionRepository;

    public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
    {
        _carDescriptionRepository = carDescriptionRepository;
    }

    public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
    {
        var value = _carDescriptionRepository.GetCarDescriptionByCarId(request.Id);
        return new GetCarDescriptionByCarIdQueryResult
        {
            Id = value.Id,
            CarId = value.CarId,
            Details = value.Details,
        };
    }
}

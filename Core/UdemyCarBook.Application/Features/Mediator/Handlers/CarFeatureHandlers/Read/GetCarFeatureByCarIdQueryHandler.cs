using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.Read;

public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
{
    private readonly ICarFeatureRepository _carFeatureRepository;

    public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
    {
        _carFeatureRepository = carFeatureRepository;
    }

    public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
    {
        var values = _carFeatureRepository.GetCarFeaturesByCarId(request.id);
        return values.Select(x => new GetCarFeatureByCarIdQueryResult
        {
            Available = x.Available,
            Id = x.Id,
            FeatureId = x.FeatureId,
            FeatureName = x.Feature.Name
        }).ToList();
    }
}

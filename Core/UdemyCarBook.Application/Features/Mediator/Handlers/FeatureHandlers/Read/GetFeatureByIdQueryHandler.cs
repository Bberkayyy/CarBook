using MediatR;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Read;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IRepository<Feature> _featureRepository;

    public GetAuthorByIdQueryHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _featureRepository.GetByIdAsync(request.Id);
        return new GetFeatureByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
        };
    }
}

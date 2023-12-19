using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers.Read;

public class GetTagCloudsByIdQueryHandler : IRequestHandler<GetTagCloudsByIdQuery, GetTagCloudsByIdQueryResult>
{
    private readonly IRepository<TagCloud> _tagCloudRepository;

    public GetTagCloudsByIdQueryHandler(IRepository<TagCloud> tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task<GetTagCloudsByIdQueryResult> Handle(GetTagCloudsByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _tagCloudRepository.GetByIdAsync(request.Id);
        return new GetTagCloudsByIdQueryResult
        {
            Id = value.Id,
            Title = value.Title,
            BlogId= value.BlogId,
        };
    }
}

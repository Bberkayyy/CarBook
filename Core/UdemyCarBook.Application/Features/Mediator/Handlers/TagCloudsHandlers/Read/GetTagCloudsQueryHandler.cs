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

public class GetTagCloudsQueryHandler : IRequestHandler<GetTagCloudsQuery, List<GetTagCloudsQueryResult>>
{
    private readonly IRepository<TagCloud> _tagCloudRepository;

    public GetTagCloudsQueryHandler(IRepository<TagCloud> tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task<List<GetTagCloudsQueryResult>> Handle(GetTagCloudsQuery request, CancellationToken cancellationToken)
    {
        var values = await _tagCloudRepository.GetAllAsync();
        return values
            .Select(x => new GetTagCloudsQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                BlogId = x.BlogId,
            })
            .ToList();
    }
}

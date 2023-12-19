using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers.Read;

public class GetTagCloudsByBlogIdQueryHandler : IRequestHandler<GetTagCloudsByBlogIdQuery, List<GetTagCloudsByBlogIdQueryResult>>
{
    private readonly ITagCloudRepository _tagCloudRepository;

    public GetTagCloudsByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
    {
        _tagCloudRepository = tagCloudRepository;
    }

    public async Task<List<GetTagCloudsByBlogIdQueryResult>> Handle(GetTagCloudsByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var values = _tagCloudRepository.GetTagCloudsByBlogId(request.Id);
        return values
            .Select(x => new GetTagCloudsByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                Id = x.Id,
                Title = x.Title,
            })
            .ToList();
    }
}

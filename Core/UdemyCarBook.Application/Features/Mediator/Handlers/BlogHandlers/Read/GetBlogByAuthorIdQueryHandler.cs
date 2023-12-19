using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInerfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var values = _blogRepository.GetBlogByAuthorId(request.Id);
        return values
            .Select(x => new GetBlogByAuthorIdQueryResult
            {
                Id = x.Id,
                AuthorName = x.Author.Name,
                AuthorId = x.Author.Id,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorDescription = x.Author.Description,
                
            })
            .ToList();
    }
}

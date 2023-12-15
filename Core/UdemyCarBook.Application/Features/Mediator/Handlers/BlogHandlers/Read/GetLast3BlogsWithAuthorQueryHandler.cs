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

public class GetLast3BlogsWithAuthorQueryHandler:IRequestHandler<GetLast3BlogsWithAuthorQuery,List<GetLast3BlogsWithAuthorQueryResult>>
{
    private readonly IBlogRepository _blogRepository;

    public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
    {
        var values =  _blogRepository.GetLast3BlogWithAuthor();
        return values
            .Select(x => new GetLast3BlogsWithAuthorQueryResult
            {
                Id = x.Id,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                Description = x.Description,
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                AuthorName = x.Author.Name
            })
            .ToList();
    }


}

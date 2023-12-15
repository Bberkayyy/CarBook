using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
{
    private readonly IRepository<Author> _AuthorRepository;

    public GetAuthorQueryHandler(IRepository<Author> AuthorRepository)
    {
        _AuthorRepository = AuthorRepository;
    }

    public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var values = await _AuthorRepository.GetAllAsync();
        return values
            .Select(x => new GetAuthorQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
            })
            .ToList();
    }
}

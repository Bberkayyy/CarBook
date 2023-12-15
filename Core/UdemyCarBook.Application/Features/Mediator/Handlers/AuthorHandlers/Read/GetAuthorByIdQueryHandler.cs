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

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    private readonly IRepository<Author> _AuthorRepository;

    public GetAuthorByIdQueryHandler(IRepository<Author> AuthorRepository)
    {
        _AuthorRepository = AuthorRepository;
    }

    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _AuthorRepository.GetByIdAsync(request.Id);
        return new GetAuthorByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            Description = value.Description,
            ImageUrl= value.ImageUrl,
        };
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    private readonly IRepository<Blog> _blogRepository;

    public GetBlogByIdQueryHandler(IRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _blogRepository.GetByIdAsync(request.Id);
        return new GetBlogByIdQueryResult
        {
            Id = value.Id,
            Title = value.Title,
            AuthorId = value.AuthorId,
            CategoryId = value.CategoryId,
            CoverImageUrl = value.CoverImageUrl,
            CreatedDate = value.CreatedDate,
            Description = value.Description,
        };
    }
}

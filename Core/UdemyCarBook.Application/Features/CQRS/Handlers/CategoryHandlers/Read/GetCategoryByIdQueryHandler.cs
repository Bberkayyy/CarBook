﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;

public class GetCategoryByIdQueryHandler
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var value = await _categoryRepository.GetByIdAsync(query.Id);
        return new GetCategoryByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name
        };
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers.Read;

public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    private readonly IRepository<Pricing> _pricingRepository;

    public GetPricingQueryHandler(IRepository<Pricing> pricingRepository)
    {
        _pricingRepository = pricingRepository;
    }

    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var values = await _pricingRepository.GetAllAsync();
        return values
            .Select(x => new GetPricingQueryResult
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();
    }
}

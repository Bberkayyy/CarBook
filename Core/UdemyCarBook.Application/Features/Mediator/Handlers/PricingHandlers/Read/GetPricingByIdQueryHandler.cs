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

public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
{
    private readonly IRepository<Pricing> _pricingRepository;

    public GetPricingByIdQueryHandler(IRepository<Pricing> pricingRepository)
    {
        _pricingRepository = pricingRepository;
    }

    public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _pricingRepository.GetByIdAsync(request.Id);
        return new GetPricingByIdQueryResult
        {
            Id = value.Id,
            Name = value.Name,
        };
    }
}

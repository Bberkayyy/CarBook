using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResult;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers.Read;

public class GetAverageRentPriceForMonthlyQueryHandler : IRequestHandler<GetAverageRentPriceForMonthlyQuery, GetAverageRentPriceForMonthlyQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetAverageRentPriceForMonthlyQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetAverageRentPriceForMonthlyQueryResult> Handle(GetAverageRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticRepository.GetAverageRentPriceForMonthly();
        return new GetAverageRentPriceForMonthlyQueryResult
        {
            AverageRentPriceForMonthly = value
        };
    }
}

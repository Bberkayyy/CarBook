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

public class GetAverageRentPriceForDailyQueryHandler : IRequestHandler<GetAverageRentPriceForDailyQuery, GetAverageRentPriceForDailyQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetAverageRentPriceForDailyQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetAverageRentPriceForDailyQueryResult> Handle(GetAverageRentPriceForDailyQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticRepository.GetAverageRentPriceForDaily();
        return new GetAverageRentPriceForDailyQueryResult
        {
            AveregePriceForDaily = value
        };
    }
}

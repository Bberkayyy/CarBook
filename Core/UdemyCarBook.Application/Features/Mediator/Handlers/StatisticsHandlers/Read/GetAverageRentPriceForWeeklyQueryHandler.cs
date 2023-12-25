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

public class GetAverageRentPriceForWeeklyQueryHandler : IRequestHandler<GetAverageRentPriceForWeeklyQuery, GetAverageRentPriceForWeeklyQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetAverageRentPriceForWeeklyQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetAverageRentPriceForWeeklyQueryResult> Handle(GetAverageRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticRepository.GetAverageRentPriceForWeekly();
        return new GetAverageRentPriceForWeeklyQueryResult
        {
            AveragePriceForWeekly = value
        };
    }
}

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

public class GetCarCountByKmLessThen1000QueryHandler : IRequestHandler<GetCarCountByKmLessThen1000Query, GetCarCountByKmLessThen1000QueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetCarCountByKmLessThen1000QueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetCarCountByKmLessThen1000QueryResult> Handle(GetCarCountByKmLessThen1000Query request, CancellationToken cancellationToken)
    {
        var value = _statisticRepository.GetCarCountByKmLessThen1000();
        return new GetCarCountByKmLessThen1000QueryResult
        {
            CarCountByKmLessThen1000 = value
        };
    }
}

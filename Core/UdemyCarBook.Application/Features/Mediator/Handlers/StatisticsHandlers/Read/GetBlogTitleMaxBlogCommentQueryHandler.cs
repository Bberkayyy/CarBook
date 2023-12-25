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

public class GetBlogTitleMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleMaxBlogCommentQuery, GetBlogTitleMaxBlogCommentQueryResult>
{
    private readonly IStatisticRepository _statisticRepository;

    public GetBlogTitleMaxBlogCommentQueryHandler(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    public async Task<GetBlogTitleMaxBlogCommentQueryResult> Handle(GetBlogTitleMaxBlogCommentQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticRepository.GetBlogTitleMaxBlogComment();
        return new GetBlogTitleMaxBlogCommentQueryResult
        {
            BlogTitleMaxBlogComment = value
        };
    }
}

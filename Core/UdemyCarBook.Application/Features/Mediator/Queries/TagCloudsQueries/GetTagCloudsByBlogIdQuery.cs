using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TagCloudsQueries;

public class GetTagCloudsByBlogIdQuery : IRequest<List<GetTagCloudsByBlogIdQueryResult>>
{
    public int Id { get; set; }

    public GetTagCloudsByBlogIdQuery(int id)
    {
        Id = id;
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TagCloudsQueries;

public class GetTagCloudsByIdQuery:IRequest<GetTagCloudsByIdQueryResult>
{
    public int Id { get; set; }

    public GetTagCloudsByIdQuery(int id)
    {
        Id = id;
    }
}

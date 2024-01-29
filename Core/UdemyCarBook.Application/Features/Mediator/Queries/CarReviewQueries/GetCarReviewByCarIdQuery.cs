using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarReviewResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarReviewQueries;

public class GetCarReviewByCarIdQuery:IRequest<List<GetCarReviewByCarIdQueryResult>>
{
    public int Id { get; set; }

    public GetCarReviewByCarIdQuery(int id)
    {
        Id = id;
    }
}

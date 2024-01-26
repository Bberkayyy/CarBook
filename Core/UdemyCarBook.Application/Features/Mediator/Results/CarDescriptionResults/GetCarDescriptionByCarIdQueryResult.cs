using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults;

public class GetCarDescriptionByCarIdQueryResult
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Details { get; set; }
}
